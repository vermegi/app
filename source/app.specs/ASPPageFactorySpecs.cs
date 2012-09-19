 using System.Web;
 using Machine.Specifications;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ASPPageFactory))]  
  public class ASPPageFactorySpecs
  {
    public abstract class concern : Observes<ICreateDisplayHandlers,
                                      ASPPageFactory>
    {
        
    }

   
    public class when_creating_a_page_to_display_a_report : concern
    {
      Establish c = () =>
      {
        path_registry = depends.on<IFindPathsToLogicalViews>();
        the_created_page = fake.an<IDisplayA<int>>();
        the_page_path = "blah.aspx";
        path_registry.setup(x => x.get_the_path_to_logical_view_for<int>()).Return(the_page_path);
        depends.on<CreateRawPage_Behaviour>((x,type) =>
        {
          x.ShouldEqual(the_page_path);
          type.ShouldEqual(typeof(IDisplayA<int>));
          return the_created_page;
        });

      };
      Because b = () =>
        result = sut.create_handler_to_display(2);

      It should_have_updated_the_Report_model_On_the_page = () =>
        the_created_page.report_model.ShouldEqual(2);
        
      It should_return_the_created_handler = () =>
        result.ShouldEqual(the_created_page);
        

      static IFindPathsToLogicalViews path_registry;
      static string the_page_path;
      static IHttpHandler result;
      static IDisplayA<int> the_created_page;
    }
  }
}
