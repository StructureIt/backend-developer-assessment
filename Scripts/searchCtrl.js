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
        $scope.artists = [
            {
                "name": "Metallica",
                "listeners": "2716774",
                "mbid": "65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab",
                "url": "https://www.last.fm/music/Metallica",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/761677ccfcd946b8a1afac23b2b863ff.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/761677ccfcd946b8a1afac23b2b863ff.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/761677ccfcd946b8a1afac23b2b863ff.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/761677ccfcd946b8a1afac23b2b863ff.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/761677ccfcd946b8a1afac23b2b863ff.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Lou Reed & Metallica",
                "listeners": "36806",
                "mbid": "9d1ebcfe-4c15-4d18-95d3-d919898638a1",
                "url": "https://www.last.fm/music/Lou+Reed+&+Metallica",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/4b17a235b2694901878d8c303eef462d.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/4b17a235b2694901878d8c303eef462d.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/4b17a235b2694901878d8c303eef462d.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/4b17a235b2694901878d8c303eef462d.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/4b17a235b2694901878d8c303eef462d.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica & DJ Spooky",
                "listeners": "11149",
                "mbid": "65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab",
                "url": "https://www.last.fm/music/Metallica+&+DJ+Spooky",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/f0e01029edb746d3852c3b8beeff91d8.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/f0e01029edb746d3852c3b8beeff91d8.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/f0e01029edb746d3852c3b8beeff91d8.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/f0e01029edb746d3852c3b8beeff91d8.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/f0e01029edb746d3852c3b8beeff91d8.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica, Michael Kamen & San Francisco Symphony Orchestra",
                "listeners": "900",
                "mbid": "",
                "url":
                    "https://www.last.fm/music/Metallica,+Michael+Kamen+&+San+Francisco+Symphony+Orchestra",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/850e7028dfa4489bb783c520494febac.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/850e7028dfa4489bb783c520494febac.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/850e7028dfa4489bb783c520494febac.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/850e7028dfa4489bb783c520494febac.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/850e7028dfa4489bb783c520494febac.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica and Ozzy Osbourne",
                "listeners": "3414",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+and+Ozzy+Osbourne",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/82a09d4a4c2d463295325056f4b58701.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/82a09d4a4c2d463295325056f4b58701.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/82a09d4a4c2d463295325056f4b58701.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/82a09d4a4c2d463295325056f4b58701.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/82a09d4a4c2d463295325056f4b58701.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica, Michael Kamen & San Francisco Symphony",
                "listeners": "732",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica,+Michael+Kamen+&+San+Francisco+Symphony",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica Tribute",
                "listeners": "2898",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+Tribute",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/26df0377d1114a95ba34fb8efe299576.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/26df0377d1114a95ba34fb8efe299576.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/26df0377d1114a95ba34fb8efe299576.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/26df0377d1114a95ba34fb8efe299576.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/26df0377d1114a95ba34fb8efe299576.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica Tribute Band",
                "listeners": "2647",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+Tribute+Band",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica & Joe Satriani",
                "listeners": "3743",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+&+Joe+Satriani",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/c8ae948ecb714d35a4cc67c64d3eafda.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/c8ae948ecb714d35a4cc67c64d3eafda.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/c8ae948ecb714d35a4cc67c64d3eafda.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/c8ae948ecb714d35a4cc67c64d3eafda.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/c8ae948ecb714d35a4cc67c64d3eafda.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica Live (LM)",
                "listeners": "3",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+Live+(LM)",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica & Michael Kamen conduct. The San Francisco Symphony Orchestra",
                "listeners": "322",
                "mbid": "",
                "url":
                    "https://www.last.fm/music/Metallica+&+Michael+Kamen+conduct.+The+San+Francisco+Symphony+Orchestra",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/c32eeed65df04239a738c2eaa1619dc4.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/c32eeed65df04239a738c2eaa1619dc4.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/c32eeed65df04239a738c2eaa1619dc4.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/c32eeed65df04239a738c2eaa1619dc4.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/c32eeed65df04239a738c2eaa1619dc4.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica Vs. Britney Spears",
                "listeners": "4187",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+Vs.+Britney+Spears",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica䑃",
                "listeners": "673",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica%E4%91%83",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/5ae64caabd654b5bcb873f033365553e.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/5ae64caabd654b5bcb873f033365553e.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/5ae64caabd654b5bcb873f033365553e.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/5ae64caabd654b5bcb873f033365553e.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/5ae64caabd654b5bcb873f033365553e.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name":
                    "Korn ,Limp bizkit, Metallica, Eminem, Disturbed, Cypress hill, Crazy town, Linkin park",
                "listeners": "6166",
                "mbid": "",
                "url":
                    "https://www.last.fm/music/Korn+,Limp+bizkit,+Metallica,+Eminem,+Disturbed,+Cypress+hill,+Crazy+town,+Linkin+park",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/36cb70985d12459dc5ae920b593ea695.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/36cb70985d12459dc5ae920b593ea695.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/36cb70985d12459dc5ae920b593ea695.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/36cb70985d12459dc5ae920b593ea695.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/36cb70985d12459dc5ae920b593ea695.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Robert Trujillo (Metallica)",
                "listeners": "5747",
                "mbid": "",
                "url": "https://www.last.fm/music/Robert+Trujillo+(Metallica)",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica - Full Arshive Bia2Seda.com",
                "listeners": "688",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+-+Full+Arshive+Bia2Seda.com",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/479ce8df8e3c40a4a9c9dd0c73362fe1.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/479ce8df8e3c40a4a9c9dd0c73362fe1.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/479ce8df8e3c40a4a9c9dd0c73362fe1.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/479ce8df8e3c40a4a9c9dd0c73362fe1.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/479ce8df8e3c40a4a9c9dd0c73362fe1.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name":
                    "Disturbed, Korn, Metallica, Linkin Park, Static X, Chevelle, Three Days Grace, Trapt, Pantera, Slipknot, Papa Roach, Freakhouse",
                "listeners": "2801",
                "mbid": "",
                "url":
                    "https://www.last.fm/music/Disturbed,+Korn,+Metallica,+Linkin+Park,+Static+X,+Chevelle,+Three+Days+Grace,+Trapt,+Pantera,+Slipknot,+Papa+Roach,+Freakhouse",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name":
                    "Limp Bizkit, Korn, Metallica, Eminem, Disturbed, Cypress Hill, Crazy Town, Linkin Park",
                "listeners": "2616",
                "mbid": "",
                "url":
                    "https://www.last.fm/music/Limp+Bizkit,+Korn,+Metallica,+Eminem,+Disturbed,+Cypress+Hill,+Crazy+Town,+Linkin+Park",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica - www.musicasparabaixar.org",
                "listeners": "187",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+-+www.musicasparabaixar.org",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/04a21ec743dc40b1c0995912c28b10e3.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/04a21ec743dc40b1c0995912c28b10e3.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/04a21ec743dc40b1c0995912c28b10e3.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/04a21ec743dc40b1c0995912c28b10e3.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/04a21ec743dc40b1c0995912c28b10e3.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica vs. Run Dmc",
                "listeners": "1724",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+vs.+Run+Dmc",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica with Ozzy Osbourne",
                "listeners": "1361",
                "mbid": "65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab",
                "url": "https://www.last.fm/music/Metallica+with+Ozzy+Osbourne",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/78742d8245454ed89cc82d457ccc0f92.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/78742d8245454ed89cc82d457ccc0f92.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/78742d8245454ed89cc82d457ccc0f92.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/78742d8245454ed89cc82d457ccc0f92.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/78742d8245454ed89cc82d457ccc0f92.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica vs. Panjabi MC",
                "listeners": "1333",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+vs.+Panjabi+MC",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/1c0e747114a34f15cf55cabd7c28fd6c.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/1c0e747114a34f15cf55cabd7c28fd6c.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/1c0e747114a34f15cf55cabd7c28fd6c.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/1c0e747114a34f15cf55cabd7c28fd6c.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/1c0e747114a34f15cf55cabd7c28fd6c.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Limp Bizkit, Eminem, Metallica, Slipknot, Korn, Deftones, Kid Rock",
                "listeners": "3836",
                "mbid": "",
                "url":
                    "https://www.last.fm/music/Limp+Bizkit,+Eminem,+Metallica,+Slipknot,+Korn,+Deftones,+Kid+Rock",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/261d0556be164b0fcb40d9e6bee13c59.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/261d0556be164b0fcb40d9e6bee13c59.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/261d0556be164b0fcb40d9e6bee13c59.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/261d0556be164b0fcb40d9e6bee13c59.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/261d0556be164b0fcb40d9e6bee13c59.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "A Tribute To Metallica",
                "listeners": "1009",
                "mbid": "",
                "url": "https://www.last.fm/music/A+Tribute+To+Metallica",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/c7f28bd4c4d94a1fad0d129a7303e144.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/c7f28bd4c4d94a1fad0d129a7303e144.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/c7f28bd4c4d94a1fad0d129a7303e144.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/c7f28bd4c4d94a1fad0d129a7303e144.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/c7f28bd4c4d94a1fad0d129a7303e144.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica (Backing Track)",
                "listeners": "470",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+(Backing+Track)",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/6ebb5a906ef1411fc185a61e94e33768.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/6ebb5a906ef1411fc185a61e94e33768.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/6ebb5a906ef1411fc185a61e94e33768.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/6ebb5a906ef1411fc185a61e94e33768.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/6ebb5a906ef1411fc185a61e94e33768.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica/San Francisco Symphony",
                "listeners": "273",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica%2FSan+Francisco+Symphony",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "korn & metallica & eminem & limp bizkit & linkin park",
                "listeners": "1200",
                "mbid": "",
                "url":
                    "https://www.last.fm/music/korn+&+metallica+&+eminem+&+limp+bizkit+&+linkin+park",
                "streamable": "0",
                "image": [
                    {
                        "#text": "",
                        "size": "small"
                    }, {
                        "#text": "",
                        "size": "medium"
                    }, {
                        "#text": "",
                        "size": "large"
                    }, {
                        "#text": "",
                        "size": "extralarge"
                    }, {
                        "#text": "",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica, San Francisco Symphony Orchestra",
                "listeners": "240",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica,+San+Francisco+Symphony+Orchestra",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/41e7d5eecaca4f6babe426b9c8871157.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/41e7d5eecaca4f6babe426b9c8871157.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/41e7d5eecaca4f6babe426b9c8871157.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/41e7d5eecaca4f6babe426b9c8871157.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/41e7d5eecaca4f6babe426b9c8871157.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica & Megadeth",
                "listeners": "1002",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+&+Megadeth",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/03d9d8d5d66e48469435bc5b666a179a.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/03d9d8d5d66e48469435bc5b666a179a.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/03d9d8d5d66e48469435bc5b666a179a.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/03d9d8d5d66e48469435bc5b666a179a.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/03d9d8d5d66e48469435bc5b666a179a.png",
                        "size": "mega"
                    }
                ]
            }, {
                "name": "Metallica / Slayer / Megadeth / Anthrax",
                "listeners": "1123",
                "mbid": "",
                "url": "https://www.last.fm/music/Metallica+%2F+Slayer+%2F+Megadeth+%2F+Anthrax",
                "streamable": "0",
                "image": [
                    {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/34s/8efd623240c143d4a0170c8ef4ecb2d1.png",
                        "size": "small"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/64s/8efd623240c143d4a0170c8ef4ecb2d1.png",
                        "size": "medium"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/174s/8efd623240c143d4a0170c8ef4ecb2d1.png",
                        "size": "large"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/300x300/8efd623240c143d4a0170c8ef4ecb2d1.png",
                        "size": "extralarge"
                    }, {
                        "#text":
                            "https://lastfm-img2.akamaized.net/i/u/8efd623240c143d4a0170c8ef4ecb2d1.png",
                        "size": "mega"
                    }
                ]
            }
        ];

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