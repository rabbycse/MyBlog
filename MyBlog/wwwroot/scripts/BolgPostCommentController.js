app.controller('BolgPostCommentController', ['$scope', '$http', 'appMessage', function ($scope, $http, appMessage) {

    //================= GLOBAL VARIABLE ===================

    $scope.appMessage = appMessage;
    $scope.BlogPostComments = [];
    $scope.filteredBlogPostComments = [];
    $scope.DataList = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 1;
    $scope.maxSize = 10;
    $scope.alerts = [];

    //=========================== Alerts ==================

    $scope.closeAlert = function (index) {
        $scope.alerts.splice(index, 1);
    };

    $scope.GetBlogPostComments = function () {
        $http({
            method: "Get",
            url: "/Blog/GetBlogPostComments"

        }).success(function mySucces(response) {

            $scope.BlogPostComments = response;
            $scope.DataList = response;
            $scope.PagingBlogPostCommentDetails();

        }).error(function myError(response) {

        });
    };

    $scope.pageChanged = function () {
        $scope.PagingBlogPostCommentDetails();
    };

    $scope.GetBlogPostComments();

    $scope.PagingBlogPostCommentDetails = function () {
        var begin = (($scope.currentPage - 1) * $scope.itemsPerPage);
        var end = begin + $scope.itemsPerPage;
        $scope.filteredBlogPostComments = $scope.DataList.slice(begin, end);
    };

    $scope.searchFromList = function () {
        $scope.DataList = $filter('filter')($scope.BlogPostComments, $scope.searchText);
        $scope.PagingBlogPostCommentDetails();
    };

}]);