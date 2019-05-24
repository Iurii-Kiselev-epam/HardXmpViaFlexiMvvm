using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.iOS.Infrastructure.Bindings;
using VacationsTracker.iOS.Infrastructure.ValueConverters;

namespace VacationsTracker.iOS.Views.Request
{
    public class VacationTypeViewController :
        BindableViewController<VacationTypeViewModel, VacationTypeParameters>
    {
        public VacationTypeViewController(VacationTypeParameters parameters)
            : base(parameters)
        {
        }

        public new VacationTypeView View
        {
            get => (VacationTypeView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView() =>
            View = new VacationTypeView();


        public override void Bind(BindingSet<VacationTypeViewModel> bindingSet)
        {
            bindingSet.Bind(View.ImageView)
                .For(v => v.BundleImageBinding())
                .To(vm => vm.VacationReason)
                .WithConversion<VacationTypeImageIdConverter>();

            bindingSet.Bind(View.Label)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationTypeUI);
        }
    }
}