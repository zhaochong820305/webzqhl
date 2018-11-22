<%@ Page Language="C#" AutoEventWireup="true" CodeFile="online.aspx.cs" Inherits="admin_online" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

.ui-draggable .ui-dialog-titlebar { cursor: move; }
.ui-dialog .ui-dialog-titlebar { padding: .4em 1em; position: relative;  }
.ui-corner-all, .ui-corner-bottom, .ui-corner-right, .ui-corner-br { -moz-border-radius-bottomright: 4px; -webkit-border-bottom-right-radius: 4px; -khtml-border-bottom-right-radius: 4px; border-bottom-right-radius: 4px; }

.ui-corner-all, .ui-corner-bottom, .ui-corner-left, .ui-corner-bl { -moz-border-radius-bottomleft: 4px; -webkit-border-bottom-left-radius: 4px; -khtml-border-bottom-left-radius: 4px; border-bottom-left-radius: 4px; }
.ui-corner-all, .ui-corner-top, .ui-corner-right, .ui-corner-tr { -moz-border-radius-topright: 4px; -webkit-border-top-right-radius: 4px; -khtml-border-top-right-radius: 4px; border-top-right-radius: 4px; }
.ui-corner-all, .ui-corner-top, .ui-corner-left, .ui-corner-tl { -moz-border-radius-topleft: 4px; -webkit-border-top-left-radius: 4px; -khtml-border-top-left-radius: 4px; border-top-left-radius: 4px; }

.ui-widget-header { border: 1px solid #e78f08; background: #f6a828 url('http://admin.miit-kjcg.org/Scripts/jqueryui/css/images/ui-bg_gloss-wave_35_f6a828_500x100.png') repeat-x 50% 50%; 
color: #ffffff; font-weight: bold; }
.ui-helper-clearfix { zoom: 1; }

*, *:before, *:after {
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}

    * {
        color: #000!important;
        text-shadow: none!important;
        background: transparent!important;
        box-shadow: none!important;
    }

    .ui-dialog .ui-dialog-titlebar-close { position: absolute; right: .3em; top: 50%; width: 19px; margin: -10px 0 0 0; padding: 1px; height: 18px; }
.ui-widget-header a { color: #ffffff; }

a {
    color: #428bca;
    text-decoration: none;
}

    a, a:visited {
        text-decoration: underline;
    }

        .ui-dialog .ui-dialog-titlebar-close span { display: block; margin: 1px; }
.ui-widget-header .ui-icon {background-image: url('http://admin.miit-kjcg.org/Scripts/jqueryui/css/images/ui-icons_ffffff_256x240.png'); }
.ui-widget-content .ui-icon {background-image: url('http://admin.miit-kjcg.org/Scripts/jqueryui/css/images/ui-icons_222222_256x240.png'); }
.ui-icon-closethick { background-position: -96px -128px; }
.ui-icon { width: 16px; height: 16px; background-image: url('http://admin.miit-kjcg.org/Scripts/jqueryui/css/images/ui-icons_222222_256x240.png'); }
.ui-icon { display: block; text-indent: -99999px; overflow: hidden; background-repeat: no-repeat; }


.ui-dialog .ui-dialog-content { position: relative; border: 0; padding: .5em 1em; background: none; overflow: auto; zoom: 1; }
.ui-widget-content { border: 1px solid #dddddd; background: #eeeeee url('http://admin.miit-kjcg.org/Scripts/jqueryui/css/images/ui-bg_highlight-soft_100_eeeeee_1x100.png') repeat-x 50% top; 
color: #333333; }

.table {
    margin-bottom: 0px;
}

.table-bordered {
    border: 1px solid #ddd;
}

    .table {
    width: 100%;
    margin-bottom: 20px;
}

    .table {
        border-collapse: collapse!important;
    }

    table {
    max-width: 100%;
    background-color: transparent;
}

table {
    border-collapse: collapse;
    border-spacing: 0;
}

.table > thead > tr > td.active, .table > tbody > tr > td.active, .table > tfoot > tr > td.active, .table > thead > tr > th.active, .table > tbody > tr > th.active, .table > tfoot > tr > th.active, .table > thead > tr.active > td, .table > tbody > tr.active > td, .table > tfoot > tr.active > td, .table > thead > tr.active > th, .table > tbody > tr.active > th, .table > tfoot > tr.active > th {
    background-color: #f5f5f5;
    /*min-width:120px;*/
}

    .table-bordered > thead > tr > th, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > tbody > tr > td, .table-bordered > tfoot > tr > td {
        border: 1px solid #ddd;
    }

    .table thead > tr > th, .table tbody > tr > th, .table tfoot > tr > th, .table thead > tr > td, .table tbody > tr > td, .table tfoot > tr > td {
        padding: 4px;
        line-height: 1.428571429;
        border-top: 1px solid #ddd;
    }

    .table-bordered th, .table-bordered td {
        border: 1px solid #ddd!important;
    }

    .table td, .table th {
        background-color: #fff!important;
    }

    th {
    text-align:center;
}

th {
    text-align: left;
}

        .auto-style1 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            企业在线提交信息</div> &nbsp;<a href ="qygl.aspx">返回企业管理</a>
        <div id="adminPopUp" class="ui-dialog-content ui-widget-content" scrollleft="0" scrolltop="0" style="width: auto; height: 451.72px; min-height: 0px; background-color: rgb(255, 255, 255);">
            <div>
                <%= str %>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>

