using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using System;
using UIKit;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Core.Presentation.ViewModels.Request;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Infrastructure.Extensions;
using VacationsTracker.iOS.Infrastructure.ValueConverters;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Request
{
    public class RequestViewController : BindableViewController<EditableVacationRequestViewModel, VacationRequestParameters>
    {
        public RequestViewController(VacationRequestParameters parameters)
            : base(parameters)
        {
            SaveBarButton = new UIBarButtonItem(Strings.Request_Save,
                UIBarButtonItemStyle.Plain, null).SetBarButtonItemStyle();

            VacationTypesPager = new UIPageViewController(
                UIPageViewControllerTransitionStyle.Scroll,
                UIPageViewControllerNavigationOrientation.Horizontal);
        }

        private UIPageViewController VacationTypesPager { get; }

        private PageViewControllerObservableDataSource VacationTypesSource { get; set; }

        public UIBarButtonItem SaveBarButton { get; }

        public new RequestView View
        {
            get => (RequestView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView() =>
            View = new RequestView();

        public override void Bind(BindingSet<EditableVacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(SaveBarButton)
                .For(v => v.ClickedBinding())
                .To(vm => vm.SaveCommand);

            bindingSet.Bind(VacationTypesSource)
                .For(v => v.ItemsBinding())
                .To(vm => vm.AllValueableVacationTypes);
            bindingSet.Bind(VacationTypesSource)
                .For(v => v.CurrentItemIndexAndCurrentItemIndexChangedBinding())
                .To(vm => vm.VacationReason)
                .WithConversion<VacationTypeCurrentItemConverter>();

            bindingSet.Bind(View.PageControl)
                .For(v => v.PagesBinding())
                .To(vm => vm.VacationTypesCount);
            bindingSet.Bind(View.PageControl)
                .For(v => v.CurrentPageAndValueChangedBinding())
                .To(vm => vm.VacationReason)
                .WithConversion<VacationTypeCurrentItemNintConverter>();

            bindingSet.Bind(View.StartDayLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.StartDay);
            bindingSet.Bind(View.StartMonthLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.ShortStartMonth);
            bindingSet.Bind(View.StartYearLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.StartYear);

            bindingSet.Bind(View.EndDayLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.EndDay);
            bindingSet.Bind(View.EndMonthLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.ShortEndMonth);
            bindingSet.Bind(View.EndYearLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.EndYear);

            bindingSet.Bind(View.VacationStatusSelector)
                .For(v => v.SelectedSegmentAndValueChangedBinding())
                .To(vm => vm.VacationStatus)
                .WithConversion<VacationStatusValueConverter>();

            bindingSet.Bind(View.DatePicker)
                .For(v => v.HiddenBinding())
                .To(vm => vm.PickerVisible)
                .WithConversion<InvertValueConverter>();

            bindingSet.Bind(View.StartControl)
                  .For(v => v.TouchUpInsideBinding())
                  .To(vm => vm.StartPickerCommand);

            bindingSet.Bind(View.EndControl)
                  .For(v => v.TouchUpInsideBinding())
                  .To(vm => vm.EndPickerCommand);

            bindingSet.Bind(View.DatePicker)
                .For(v => v.DateAndValueChangedBinding())
                .To(vm => vm.PickerValue)
                .WithConversion<DatePickerDateValueConverter>();
            bindingSet.Bind(View.DatePicker)
                .For(v => v.MinimumDateBinding())
                .To(vm => vm.MinValue)
                .WithConversion<DatePickerDateValueConverter>();
            bindingSet.Bind(View.DatePicker)
                .For(v => v.MaximumDateBinding())
                .To(vm => vm.MaxValue)
                .WithConversion<DatePickerDateValueConverter>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationController.NotNull().NavigationBarHidden = false;

            VacationTypesSource = new PageViewControllerObservableDataSource(VacationTypesPager, PagesFactory);
            VacationTypesSource.CurrentItemIndexChangedWeakSubscribe(OnPageChanged);

            // https://stackoverflow.com/questions/13347813/uipagecontrol-not-visible-when-combined-with-uiscrollview
            VacationTypesPager.View.BackgroundColor = UIColor.White;
            VacationTypesPager.DataSource = VacationTypesSource;

            this.AddChildViewControllerAndView(VacationTypesPager, View.VacationTypesPagerView);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Title = Strings.Request_Title;

            NavigationItem.RightBarButtonItem = SaveBarButton;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            HideKeyboard();
        }

        private void HideKeyboard() =>
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);


        private UIViewController PagesFactory(object parameters)
        {
            if (parameters is VacationTypeParameters vtParameters)
                return new VacationTypeViewController(vtParameters);
            throw new ArgumentException(nameof(parameters));
        }

        private void OnPageChanged(object sender, IndexChangedEventArgs e)
        {
            View.PageControl.CurrentPage = e.Index;
        }
    }
}