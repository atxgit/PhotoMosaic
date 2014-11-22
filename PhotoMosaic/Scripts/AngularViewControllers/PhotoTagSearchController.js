myApp.controller("PhotoTagSearchController", function ($scope, $http, $window) {

    $scope.PhotoTagSearchResults = [];
    $scope.searchCriteriaString = "";

    $scope.QueryData = function () {

        if ($scope.searchCriteriaString.length > 3) {

            var request = $http({
                method: "get",
                url: "/api/photoTagSet",
                params: {
                    criteriaString: $scope.searchCriteriaString,
                    pageIndex: 1,
                    pageSize: 10,
                    authToken: "",
                    authDevice: ""
                }
            }).success(function (data) {
                $scope.PhotoTagSearchResults = data; // response data 
            });

        } else {
            $scope.PhotoTagSearchResults = [];
        }
    };


});