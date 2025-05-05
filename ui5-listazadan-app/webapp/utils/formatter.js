sap.ui.define([
], function (
) {
  "use strict";

  return {
    formatDate : function(todoDate){
        var oToday = new Date(),
            iDaysBetween = (todoDate.getTime() - oToday.getTime())/(1000*60*60*24);
        if(iDaysBetween>=3){
          return "Success";
        } else if(iDaysBetween>0){
          return "Warning";
        } else {
          return "Error";
        }
    }
  };
});