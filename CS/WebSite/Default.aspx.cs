using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.XtraPivotGrid;
using System.ComponentModel;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e) {
        PivotDrillDownDataSource ds = ASPxPivotGrid1.CreateDrillDownDataSource(0, 0);
        PropertyDescriptorCollection props = ((ITypedList)ds).GetItemProperties(null);

        DataTable table = new DataTable("drilldown");
        for(int i = 0; i < props.Count; i++) {
            table.Columns.Add(props[i].Name, props[i].PropertyType);
        }
        object[] row = new object[props.Count];
        for(int i = 0; i < ds.RowCount; i++) {
            for(int j = 0; j < props.Count; j++) {
                row[j] = ds.GetValue(i, j);
            }
            table.Rows.Add(row);
        }
        using(StringWriter writer = new StringWriter()) {
            table.WriteXml(writer, XmlWriteMode.WriteSchema);
            Session["drilldown"] = writer.ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e) {
        string serializedXml = Session["drilldown"] as string;
        if(string.IsNullOrEmpty(serializedXml)) return;
        DataTable table = new DataTable();
        using(StringReader reader = new StringReader(serializedXml))
            table.ReadXml(reader);
    }
}
