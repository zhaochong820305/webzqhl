<%@ Page Language="C#" AutoEventWireup="true" CodeFile="projectadd.aspx.cs" Inherits="admin_projectadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />

    <%--<script src="js/jquery-ui.min.js"></script>   
    <script src="js/jquery-1.4.4.min.js"></script>   
    <script src="js/jquery.ui.datepicker-zh-CN.js"></script>--%>
    <link href="css/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="js/date/jquery-1.8.1.js"></script>
    <script type="text/javascript" src="js/date/jquery-ui.js"></script>
    <script type="text/javascript" src="js/date/dateinput-ch-ZN.js"></script>
    <%--    <link href="css/red-datepicker.css" rel="stylesheet">--%>
    <script>
        $(document).ready(function () {
            $('#tbSDate').datepicker(); //绑定输入框
            $('#tbEDate').datepicker(); //绑定输入框
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="gridtable">
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">选择企业：</th>
                <td colspan="3">
                    <div class="input-group">
<asp:DropDownList ID="ddlCompany" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">项目名称：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">项目目标：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbMuBiao" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">项目规模(万元)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbGuiGe" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">固定资产投资(万元)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbGuDing" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">非固定资产投资(万元)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbnoGuDing" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px"  >开始时间：</th>
                <td class="auto-style2" colspan="3">
                    <asp:TextBox ID="tbSDate" runat="server" CssClass="date-pick"  ></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;" >结束时间：</th>
                <td class="auto-style1" colspan="3">
                    <asp:TextBox ID="tbEDate" runat="server" CssClass="date-pick" ></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">项目进度(%)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbJinDu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">项目性质：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ddlXingZhi" runat="server" Height="22px" Width="246px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 273px">军工情况：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ddlJunGong" runat="server" Height="22px" Width="246px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
                    <asp:Label ID="Label1" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="Project.aspx" class="buttonLB1">返回项目列表</a>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
