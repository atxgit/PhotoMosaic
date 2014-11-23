myApp.controller("PhotoTagSearchController", function ($scope, $http, $window) {

    $scope.PhotoTagSearchResults = [];
    $scope.PhotoTagsCollection = [];
    $scope.searchCriteriaString = "";


    $scope.PhotoTagSelected = function (index) {
        if (index >= 0 && index < $scope.PhotoTagSearchResults.PhotoTags.length) {
            var selectedTag = $scope.PhotoTagSearchResults.PhotoTags[index];

            $scope.AddPhotoTag(selectedTag);            
        }
    }

    $scope.AddPhotoTag = function (photoTag) {
        $scope.PhotoTagsCollection.push(photoTag);
    }

    $scope.DeletePhotoTag = function (index) {
        $scope.PhotoTagsCollection.splice(index, 1);
    }

    $scope.KeyUp = function (keyEvent) {
        if (keyEvent.keyCode == 27) {
            // escape --            
            $scope.searchCriteriaString = "";
            $scope.PhotoTagSearchResults = [];
        } else if (keyEvent.keyCode == 37 || keyEvent.keyCode == 38) {
            // up and left --            
        } else if (keyEvent.keyCode == 39 || keyEvent.keyCode == 40) {
            // right and down --            
        } else {
            if ($scope.searchCriteriaString.length > 1) {
                $scope.QueryData();
            } else {
                $scope.PhotoTagSearchResults = [];
            }
        }
    };

    $scope.QueryData = function () {

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

    };


});

