<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="TestExtJSApp.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="extjs/resources/css/ext-all.css"/>
     <script type="text/javascript" src="extjs/ext-all-debug.js"></script>
     <script>

         ///прокси с параметрами в формате json
         Ext.define('TestApp.proxy.JsonProxy', {
             alias: 'proxy.jproxy',
             extend: 'Ext.data.proxy.Ajax',

             buildRequest: function (operation) {
                 var request = this.callParent(arguments);

                 // For documentation on jsonData see Ext.Ajax.request
                 request.jsonData = request.params;
                 request.params = {};

                 return request;
             },

             getMethod: function (request) {
                 return 'POST';
             }
         });

         // модель данных
         Ext.define('Data', {
             extend: 'Ext.data.Model',
             fields: [
                 { name: 'Id', type: 'int' },
                 { name: 'Country', type: 'string' },
                 { name: 'City', type: 'string' },
                 { name: 'House', type: 'string' }
             ]
         });

         Ext.application({
             name: 'TestExt',
             launch: function () {
                 Ext.create('Ext.container.Viewport', {
                     layout: 'fit',
                     items: [
                         {
                             autoScroll: true,
                             title: 'Test Ext',
                             xtype: 'panel',
                             layout:'form',
                             items: [
                                 {
                                     //тип дочернего элемента
                                     xtype: 'grid',
//                                     autoScroll: true,
                                     //модель столбцов таблицы
                                     columns: [
                                        {
                                            header: 'Страна',
                                            dataIndex: 'Country',
                                            width:"30%"
                                        },
                                        {
                                            header: 'Город',
                                            dataIndex: 'City',
                                            width: "35%"
                                        },
                                        {
                                            header: 'Дом',
                                            dataIndex: 'House',
                                            width: "35%"
                                        }
                                     ]
                                     ,
                                     /// хранилище полученных данных
                                     store: new Ext.data.JsonStore({
                                         model:'Data',
                                         proxy: {
                                             type: 'jproxy',                                             
                                             url: '/Services/DataService.svc/GetData',
                                             actionMethods:{read: 'POST'},
                                             reader: {
                                                 type: 'json',
                                                 root: 'data',
                                                 idProperty: 'id',
                                             }

                                         },
                                         autoLoad: true
                                     })
                                 }
                             ]
                         }
                     ]
                 });
             }
         });
     </script>

</head>
<body>
</body>
</html>
