<%@ Page Title="" Language="C#" MasterPageFile="~/PropertyNew.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="SoldHouse.aspx.cs" Inherits="Property.SoldHouse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
 
<%@ Register TagName="ContactInfo" TagPrefix="uc" Src="~/Controls/ContactInfo.ascx" %>
<%@ Register TagName="SearchBar" TagPrefix="uc" Src="~/Controls/SearchBar.ascx" %>
<%@ Register Src="~/Controls/SoldHouseControl.ascx" TagPrefix="uc" TagName="SoldHouseControl" %>
 

<%@ Register Src="~/Controls/SearchControl.ascx" TagPrefix="uc" TagName="SearchControl" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:ToolkitScriptManager>
    
    <div>
        <div class="left_section_bg">
            <div class="left_section_in_5">
                <div class="my_list_hdng">
                <h2>Sold Properties</h2>
                     </div>
                    <div class="In_bg">                       
                        <uc:SoldHouseControl runat="server" id="SoldHouseControl" />
                    </div>
                   
               
            </div>
        </div>
    </div>
</asp:Content>
