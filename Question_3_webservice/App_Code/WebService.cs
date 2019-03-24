using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetPayLoadasString(string inputDocument)
    {
        //Use example
        //    WebService obj = new WebService();
        //    XDocument xDocument = XDocument.Load(@"c:\temp\PayLoad.xml");
        //    string result = obj.GetPayLoadasString(xDocument.ToString());
        try
        {
            XDocument xDocument = XDocument.Parse(inputDocument);

            var docInfo = xDocument.Descendants("Declaration").FirstOrDefault();
            string declarationCommand = docInfo.Attribute("Command").Value;

            var declarationHeaderDescendants = xDocument.Descendants("DeclarationHeader");
            var siteID = declarationHeaderDescendants.Elements("SiteID").FirstOrDefault().Value;

            if (declarationCommand != "DEFAULT")
            {
                return "-1";
            }
            else if (siteID != "DUB")
            {
                return "-2";
            }
            else
            {
                return "0";
            }
        }
        catch
        {
            return "Sorry, something went wrong!";
        }

    }

}
