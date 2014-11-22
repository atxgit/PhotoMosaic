var myApp = angular.module('pmApp', []);

myApp.controller("PhotoSetController", function ($scope, $http, $window) {

    $scope.ClientViewData = new ClientViewData();

    $scope.UpdateLayout = function () {
        $scope.ClientViewData = new ClientViewData();
        $scope.photoSetGroups = formatPhotoSetForClientByGroup($scope.photoSetOriginal, $scope.ClientViewData);
        $scope.$apply();
    };

    $scope.QueryData = function() {
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
        }).success(function(data) {
            $scope.photoSetOriginal = data; // response data 
            $scope.UpdateLayout();
        });
    };
    
    $scope.QueryData();

    angular.element($window).bind('resize', debouncerUtility(function (e) {
        $scope.UpdateLayout();

        if( $scope.photoSetOriginal.Photos.length < $scope.ClientViewData.ThumbCount)
        {
            $scope.QueryData();
        }
    }));
    
    });

    function formatPhotoSetForClientByGroup( photoSetJSON, clientViewData ) {
        var result = {};
        result.Groups = [];

        var curGroup = { "Group": null, "GroupColor":  null };

        for (i = 0; i < photoSetJSON.Photos.length; i++) {
            var photo = photoSetJSON.Photos[i];

            if (curGroup.Group != photo.Group || i % clientViewData.ThumbCountSize.Width == 0) {
                curGroup = {
                    "Group": photo.Group,
                    "GroupColor": photo.GroupColor,
                    "Photos": []
                };

                result.Groups.push(curGroup);
            }

            curGroup.Photos.push(photo);
        }

        return result;
    }