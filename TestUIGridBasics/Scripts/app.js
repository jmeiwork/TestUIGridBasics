var app = angular.module('app', ['ngTouch', 'ui.grid', 'ui.grid.edit', 'ui.grid.autoResize']);

app.controller('MainCtrl', ['$scope', '$http', 'uiGridConstants', function ($scope, $http, uiGridConstants) {
    $scope.gridOptions = {
        rowTemplate: '<div ng-class="{\'row-standard\':true, \'row-target\':row.entity.ResultType===\'Target\', \'row-ending-inventory\':row.entity.ResultType===\'EndingInventory\', \'row-total\':row.entity.ResultType===\'Total\', \'row-adjustment-header\':row.entity.ResultType===\'AdjustmentHeader\', \'row-supply-detail\':row.entity.ResultType===\'SupplyDetail\', \'row-supply-header\':row.entity.ResultType===\'SupplyHeader\' }">'
            + '<div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader }" ui-grid-cell></div></div>',
        enableHorizontalScrollbar: uiGridConstants.scrollbars.NEVER,
        enableVerticalScrollbar: uiGridConstants.scrollbars.NEVER
    };

        $scope.gridData = {
            rowHeight: 30
        };

    $scope.gridOptions.columnDefs = [
      { field: 'Amounts.Label', displayName: 'Grade', enableCellEdit: false, width: '16%', enableSorting: false },
      { field: 'Amounts.Jan', displayName: 'Jan', width: '7%', enableSorting: false },
      { field: 'Amounts.Feb', displayName: 'Feb', width: '7%', enableSorting: false },
      { field: 'Amounts.Mar', displayName: 'Mar', width: '7%', enableSorting: false },
      { field: 'Amounts.Apr', displayName: 'Apr', width: '7%', enableSorting: false },
      { field: 'Amounts.May', displayName: 'May', width: '7%', enableSorting: false },
      { field: 'Amounts.Jun', displayName: 'Jun', width: '7%', enableSorting: false },
      { field: 'Amounts.Jul', displayName: 'Jul', width: '7%', enableSorting: false },
      { field: 'Amounts.Aug', displayName: 'Aug', width: '7%', enableSorting: false },
      { field: 'Amounts.Sep', displayName: 'Sep', width: '7%', enableSorting: false },
      { field: 'Amounts.Oct', displayName: 'Oct', width: '7%', enableSorting: false },
      { field: 'Amounts.Nov', displayName: 'Nov', width: '7%', enableSorting: false },
      { field: 'Amounts.Dec', displayName: 'Dec', width: '7%', enableSorting: false }
    ];

    $scope.msg = {};

    $scope.getTableHeight = function () {
        var rowHeight = 30; // your row height
        var headerHeight = 30; // your header height
        return {
            height: ($scope.gridData.data.length * rowHeight + headerHeight) + "px"
        };
    };

    $scope.gridOptions.onRegisterApi = function (gridApi) {
        //set gridApi on scope
        $scope.gridApi = gridApi;
        gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
            $scope.msg.lastCellEdited = 'edited row id:' + rowEntity.id + ' Column:' + colDef.name + ' newValue:' + newValue + ' oldValue:' + oldValue;
            $scope.$apply();
        });
    };

    //    $http.get('http://ui-grid.info/data/500_complex.json')
    $http.get('/api/searchresults')
      .success(function (data) {
          //for (i = 0; i < data.length; i++) {
          //    data[i].registered = new Date(data[i].registered);
          //    data[i].gender = data[i].gender === 'male' ? 1 : 2;
          //    if (i % 2) {
          //        data[i].pet = 'fish'
          //        data[i].foo = { bar: [{ baz: 2, options: [{ value: 'fish' }, { value: 'hamster' }] }] }
          //    }
          //    else {
          //        data[i].pet = 'dog'
          //        data[i].foo = { bar: [{ baz: 2, options: [{ value: 'dog' }, { value: 'cat' }] }] }
          //    }
          //}
            var currentGrade = data[0] === undefined ? '-' : data[0].Grade;
            $scope.gridOptions.columnDefs[0].displayName = currentGrade;

          $scope.gridOptions.data = data;
      });
}])

;