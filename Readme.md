<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to save and load a drilldown datasource into a session


<p>The result returned by the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CreateDrillDownDataSourcetopic">CreateDrillDownDataSource</a> method is not serializable. A possible solution is to move this data to a DataTable, convert it to XML, and save it to the Session. Then, you will be able to restore this DataSet from the XML data stored in the Session. This example illustrates how this can be done.</p><p>The <helplink href="ms-help://MS.VSCC.v90/MS.VSIPCC.v90/DevExpress.NETv10.1/DevExpress.CoreLibraries/clsDevExpressXtraPivotGridPivotDrillDownDataSourcetopic.htm">PivotDrillDownDataSource class</link> implements both ITypedList and IList interfaces, which provide a .NET-standard data access. So, these interfaces can be used to fill a DataTable object with columns and rows.</p>

<br/>


