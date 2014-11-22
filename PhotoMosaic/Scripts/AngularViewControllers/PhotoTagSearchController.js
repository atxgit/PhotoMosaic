myApp.controller("PhotoTagSearchController", function ($scope, $http, $window) {

    $scope.PhotoTagSearchResults

    $scope.QueryData = function () {
        var request = $http({
            method: "get",
            url: "/api/photoset",
            params: {
                criteriaString: "",
                pageIndex: 1,
                pageSize: $scope.ClientViewData.ThumbCount,
                authToken: "",
                authDevice: ""
            }
        }).success(function (data) {
            $scope.photoSetOriginal = data; // response data 
            $scope.UpdateLayout();
        });
    };


});