var app = angular.module("musicsearchApp", []);
app.controller("searchCtrl",
    function($scope, $http) {
        $scope.showResults = false;
        $scope.favourites = {};
        $scope.shortListArtist = {};

        console.log("Application started");
        var siteUrl = "http://musicbrainz.org/ws/2";
        var lastFmApiUrl =
            "http://ws.audioscrobbler.com/2.0/?method=artist.search&api_key=36ec72d3d051ac287de9bed61fe2657e&format=json&artist=";

        //Default artist list just to populate on page load
        $scope.artists = [];

        $("#query").keypress(function (e) {
            if (e.which === 13) {
                console.log('Call search button click');
                $("#search").click();
            }
        });

        $("#search")
            .click(function() {

                $scope.showResults = false;
                if ($("#query").val() === '') {
                    alert("Search string cannot be empty, Please enter a valid search string...");
                    return;
                }

                $scope.artists = [];

                var searchUrl = siteUrl + "/artist?" + $(":input").serialize();

                if ($("li.active a").text() !== "MusicBrainz") {
                    searchUrl = lastFmApiUrl + encodeURIComponent($("#query").val());
                    console.log(searchUrl);
                }

                console.log(searchUrl);

                $http.get(searchUrl)
                    .then(function(response) {
                            console.log('Artist search successful');
                            if (response.data.artists) {
                                $scope.artists = $scope.MapToList(response.data.artists, true);
                                return;
                            }

                            if (response.data.results && response.data.results.artistmatches.artist) {
                                $scope.artists = $scope.MapToList(response.data.results.artistmatches.artist, true);
                            }
                        },
                        function(error) {
                            console.log("Error message from search query" + error.message);
                        });
            });

        $scope.getReleases = function(artistid, index) {
            var releaseUrl = siteUrl + "/release?artist=" + artistid + "&inc=labels+recordings&fmt=json";
            console.log(releaseUrl);

            var isArtist = false;
            var $showElement = document.getElementById("show" + index);
            var $hideElement = document.getElementById("hide" + index);
            var $resultsElement = document.getElementById("results" + index);

            if ($showElement.className === "hide") {
                $showElement.className = "show";
                $hideElement.className = "hide";
                $resultsElement.className = "hide";
            } else {
                $showElement.className = "hide";
                $hideElement.className = "show";
                $resultsElement.className = "show";
            }

            var filterdValue = $scope.artistFilter(artistid);
            if (filterdValue === undefined) {
                alert("No releases found");
                console.log("No match found for " + id);
                return;
            }
            console.log(filterdValue);

            if ($(filterdValue) && $(filterdValue)[0].releases.length === 0) {
                $http.get(releaseUrl)
                    .then(function(response) {
                            console.log('Artists releases retreived');
                            // Identify the artist record and append its releases
                            if (response.data.releases.length > 0 && filterdValue) {
                                $(filterdValue)[0].releases = $scope.MapToList(response.data.releases, isArtist);
                                $resultsElement.className = "show";
                            } else {
                                $resultsElement.className = "hide";
                            }
                        },
                        function(error) {
                            console.log("Error message from search query" + error.message);
                        });
            }
            $scope.showResults = !$scope.showResults;
        };

        $scope.artistFilter = function(id) {
            var filterList = jQuery.grep($scope.artists,
                function(art) {
                    console.log("Artist Id = " + art.mbid);
                    if (art.mbid === id) {
                        console.log("Id found to set releases" + id);
                        return art;
                    }
                    return undefined;
                });
            return filterList;
        };

        $scope.MapToList = function(items, isArtist) {
            var list = [];
            $(items)
                .each(function(i, item) {
                    var newItem = isArtist ? $scope.MapToArtist(item) : $scope.MapToRelease(item);
                    list.push(newItem);
                });
            return list;
        };

        $scope.MapToArtist = function(artistSource) {
            return {
                name: artistSource.name,
                mbid: artistSource.mbid || artistSource.id,
                url: artistSource.url || '', // www.last.fm/music/Metallica",
                image: artistSource.image || [],
                releases: [],
                show: true,
                isFavorite: false
            };
        };

        $scope.MapToRelease = function(releaseSource) {
            return {
                title: releaseSource.title,
                label: releaseSource["label-info"][0] ? releaseSource["label-info"][0].label.name : '',
                numberOfTracks: releaseSource.media[0]["track-count"],
                date: releaseSource.date && releaseSource.date.split('-') ? releaseSource.date.split('-')[0] : '',
                isFavorite: false
            };
        };

        $scope.addToShortList = function(mbid, name) {
            $scope.shortListArtist[mbid] = name;
            console.log($scope.shortListArtist);
            if(localStorage){
                localStorage.setItem("shortListArtist", JSON.stringify($scope.shortListArtist));
            }
        }

        $scope.addToFavourites = function(mbid, name) {
            $scope.favourites[mbid] = name;
            console.log('After adding items');
            console.log($scope.favourites);

            $scope.updateFavouritesToStorage();
        };

        $scope.removeFromFavourites = function(mbid, name) {
            if ($scope.favourites.hasOwnProperty(mbid)) {
                // Remove item
                delete $scope.favourites[mbid];
            }
            console.log('After Item removed from favourites');
            console.log($scope.favourites);

            $scope.updateFavouritesToStorage();
        };

        $scope.updateFavouritesToStorage = function() {
            if (localStorage) {
                localStorage.setItem("favourites", JSON.stringify($scope.favourites));
            }
        };

        $scope.returnFromLocalStorage = function (storageName) {
            
            if (storageName === "favourites") {
                var itemsRetrieved = localStorage.favourites;
                $scope.favourites = JSON.parse(itemsRetrieved);
            }

            if (storageName === "shortlist") {
                var shortlist = localStorage.shortListArtist;
                $scope.shortListArtist = JSON.parse(shortlist);
            }
            return {key:"NoItems", value:"No short listed Items"};
        };
        
    });