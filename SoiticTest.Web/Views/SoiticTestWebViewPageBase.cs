using Abp.Web.Mvc.Views;

namespace SoiticTest.Web.Views
{
    public abstract class SoiticTestWebViewPageBase : SoiticTestWebViewPageBase<dynamic>
    {

    }

    public abstract class SoiticTestWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SoiticTestWebViewPageBase()
        {
            LocalizationSourceName = SoiticTestConsts.LocalizationSourceName;
        }
    }
}