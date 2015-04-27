var app = angular.module('app', ['ngTouch', 'ui.grid', 'ui.grid.edit', 'ui.grid.autoResize']);

app.controller('MainCtrl', ['$scope', '$http', 'uiGridConstants', function ($scope, $http, uiGridConstants) {
    var commonGridOptions = {
        rowTemplate: '<div ng-class="{\'row-standard\':true, \'row-target\':row.entity.ResultType===\'Target\', \'row-ending-inventory\':row.entity.ResultType===\'EndingInventory\', \'row-total\':row.entity.ResultType===\'Total\', \'row-adjustment-header\':row.entity.ResultType===\'AdjustmentHeader\', \'row-supply-detail\':row.entity.ResultType===\'SupplyDetail\', \'row-supply-header\':row.entity.ResultType===\'SupplyHeader\' }">'
            + '<div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader }" ui-grid-cell></div></div>',
        enableHorizontalScrollbar: uiGridConstants.scrollbars.NEVER,
        enableVerticalScrollbar: uiGridConstants.scrollbars.NEVER,
        rowHeight:20
    };
    $scope.gridOptions = commonGridOptions;
    $scope.gridOptions2 = commonGridOptions;

    $scope.getCellTemplate = function (month) {
        return '<div class="ui-grid-cell-contents" title="TOOLTIP">{{grid.appScope.cumulative(grid, row, "' + month + '")}}</div>';
    }

    $scope.getHeaderCellTemplate = function () {
        return '<div ng-class="{ \'sortable\': sortable }">' +
  '<div class="ui-grid-cell-contents" col-index="renderIndex">' +
    '<span>{{ col.displayName CUSTOM_FILTERS }}</span>' +
    '<span ui-grid-visible="col.sort.direction" ng-class="{ \'ui-grid-icon-up-dir\': col.sort.direction == asc, \'ui-grid-icon-down-dir\': col.sort.direction == desc, \'ui-grid-icon-blank\': !col.sort.direction }">&nbsp;</span>' +
  '</div>' +
  '<div ui-grid-filter></div>' +
'</div>';
    }

    $scope.gridOptions.columnDefs = [
      { field: 'Amounts.Label', displayName: 'Grade', enableCellEdit: false, width: '16%', enableSorting: false, headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Jan', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Jan'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Feb', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Feb'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Mar', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Mar'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Apr', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Apr'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.May', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('May'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Jun', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Jun'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Jul', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Jul'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Aug', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Aug'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Sep', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Sep'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Oct', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Oct'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Nov', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Nov'), headerCellTemplate: $scope.getHeaderCellTemplate() },
      { field: 'Amounts.Dec', displayName: '', width: '7%', enableSorting: false, cellTemplate: $scope.getCellTemplate('Dec'), headerCellTemplate: $scope.getHeaderCellTemplate() }
    ];

    $scope.msg = {};


    $scope.cumulative = function (grid, myRow, month) {
        var myRowFound = false;
        var returnValue = 0;

        if (myRow.entity.ResultType === 'Total') {
            grid.renderContainers.body.visibleRowCache.forEach(function (row, index) {
                if (!myRowFound) {
                    if (row === myRow) {
                        myRowFound = true;
                    } else {
                        if (row.entity.ResultType === 'SupplyDetail' || row.entity.ResultType === 'AdjustmentDetail') {
                            returnValue += Number(row.entity.Amounts[month]);

                        }

                    }
                }
            });
            
        } else {
            returnValue = myRow.entity.Amounts[month];
        }

        return returnValue;
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

          //Loop through the data and make modifications for display purposes
          
          data.unshift({ "PoolCategory": "Standard", "Grade": "RSTD", "Notes": "This is a note.", "ResultType": "Title", "Amounts": { "Label": "", "Jan": "Jan", "Feb": "Feb", "Mar": "Mar", "Apr": "Apr", "May": "May", "Jun": "Jun", "Jul": "Jul", "Aug": "Aug", "Sep": "Sep", "Oct": "Oct", "Nov": "Nov", "Dec": "Dec" } });
          

            var currentGrade = data[0] === undefined ? '-' : data[0].Grade;
            $scope.gridOptions.columnDefs[0].displayName = currentGrade;

            $scope.gridOptions.data = data;
      });
}])

;