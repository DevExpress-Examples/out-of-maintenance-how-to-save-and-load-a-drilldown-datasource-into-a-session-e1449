﻿<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dxwpg:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" DataSourceID="AccessDataSource1">
			<Fields>
				<dxwpg:PivotGridField ID="fieldCategoryName" Area="RowArea" AreaIndex="0" FieldName="CategoryName">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldProductName" Area="RowArea" AreaIndex="1" FieldName="ProductName">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldProductSales" Area="DataArea" AreaIndex="0" FieldName="ProductSales">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldShippedDate" Area="ColumnArea" AreaIndex="0" FieldName="ShippedDate"
					GroupInterval="DateYear" UnboundFieldName="fieldShippedDate">
				</dxwpg:PivotGridField>
			</Fields>
		</dxwpg:ASPxPivotGrid>
		<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
			SelectCommand="SELECT * FROM [ProductReports]"></asp:AccessDataSource>
		&nbsp;
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
		<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Load" /></div>
	</form>
</body>
</html>