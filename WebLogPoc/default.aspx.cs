using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudService.Common.Logging;
using CloudService.FactoryLogger;

namespace WebLogPoc
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Verficar o Web.Config que configura o procedimento para qual local será Gravado e que formato será gravado
            //http://www.eidias.com/blog/2012/10/15/simple-logging-with-use-of-systemdiagnostictrace
            //https://msdn.microsoft.com/en-us/library/hfaf9h0e(v=vs.110).aspx
            ILogger objlog = CloudService.Common.Logging.LoggerFactory<FactoryLogger>.GetLogger();
            objlog.Information("campo {0} informado", TextBox1.Text);
            Label1.Text = "Procedimento de Log realizado as" + DateTime.Now.ToLongTimeString();
            
            
        }
    }
}