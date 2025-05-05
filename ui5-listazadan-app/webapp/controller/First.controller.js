sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "in/sijas/todolist/utils/formatter",
    "sap/ui/core/Fragment",
    "sap/ui/model/json/JSONModel"
],
    /**
     * @param {typeof sap.ui.core.mvc.Controller} Controller
     */
    function (Controller,
        formatter,
        Fragment,
        JSONModel) {
        "use strict";

        return Controller.extend("in.sijas.todolist.controller.First", {
            formatter: formatter,
            onInit: function () {

            },
            setToComplete: function (oEvt) {
                var oSource = oEvt.getSource(),
                    oContext = oSource.getBindingContext("mTodo"),
                    oModel = this.getView().getModel("mTodo");

                oModel.setProperty("status", "1", oContext);
            },
            createTodo: function () {
                var oData = {
                    title: "",
                    description: "",
                    targetDate: new Date("07/21/2023"),
                    status: 0
                };
                if (!this.createDialog) {
                    this.createDialog = Fragment.load({
                        type: "XML",
                        name: "in.sijas.todolist.fragment.create",
                        controller: this
                    }).then(function (oDialog) {
                        oDialog.setModel(new JSONModel(oData), "mCreate");
                        this.getView().addDependent(oDialog);
                        return oDialog;
                    }.bind(this))
                }
                this.createDialog.then(function (oDialog) {
                    oDialog.open();
                    oDialog.getModel("mCreate").setData(oData);
                });
            },
            saveTodo: function () {
                var oTodoModel = this.getView().getModel("mTodo"),
                    aData = oTodoModel.getData();
                this.createDialog.then(function (oDialog) {
                    var oData = oDialog.getModel("mCreate").getData();
                    aData.todo_list.unshift(oData);
                    oTodoModel.setData(aData);
                    oDialog.close();
                });
            },
            deleteTodo: function (oEvt) {
                var oSource = oEvt.getParameter("listItem"),
                    oContext = oSource.getBindingContext("mTodo"),
                    mTodo = this.getView().getModel("mTodo"),
                    aData = mTodo.getData(),
                    sPath = oContext.getPath(),
                    iIndex = sPath.split("/")[2];
                aData.todo_list.splice(iIndex, 1);
                mTodo.setData(aData);
            }
        });
    });
