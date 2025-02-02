﻿gapi.analytics.ready(function () {
    /**
     * Authorize the user immediately if the user has already granted access.
     * If no access has been created, render an authorize button inside the
     * element with the ID "embed-api-auth-container".
     */
    gapi.analytics.auth.authorize({
        container: 'embed-api-campaigns',
        clientid: '741820747648-0q7381obn2s853don1f4h72gctofpns3.apps.googleusercontent.com'
    });

    /**
      * Create a ViewSelector for the first view to be rendered inside of an
      * element with the id "view-selector-1-container".
      */
    var viewSelector1 = new gapi.analytics.ViewSelector({
        container: 'view-selector-1-container'
    });

    /**
     * Create a ViewSelector for the second view to be rendered inside of an
     * element with the id "view-selector-2-container".
     */
    var viewSelector2 = new gapi.analytics.ViewSelector({
        container: 'view-selector-2-container'
    });

    // Render both view selectors to the page.
    viewSelector1.execute();
    viewSelector2.execute();


    /**
     * Create the first DataChart for top countries over the past 30 days.
     * It will be rendered inside an element with the id "chart-1-container".
     */
    var dataChart1 = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: 'ga:sessions',
            dimensions: 'ga:campaign',
            'start-date': '30daysAgo',
            'end-date': 'yesterday',
            'max-results': 8,
            sort: '-ga:sessions'
        },
        chart: {
            container: 'chart-1-container',
            type: 'PIE',
            options: {
                width: '100%',
                pieHole: 4 / 12
            }
        }
    });

    /**
     * Create the second DataChart for top countries over the past 30 days.
     * It will be rendered inside an element with the id "chart-2-container".
     */
    var dataChart2 = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: 'ga:sessions',
            dimensions: 'ga:medium',
            'start-date': '30daysAgo',
            'end-date': 'yesterday',
            'max-results': 8,
            sort: '-ga:sessions'
        },
        chart: {
            container: 'chart-2-container',
            type: 'PIE',
            options: {
                width: '100%',
                pieHole: 4 / 12
            }
        }
    });

    /**
     * Update the first dataChart when the first view selecter is changed.
     */
    viewSelector1.on('change', function (ids) {
        dataChart1.set({ query: { ids: ids } }).execute();
    });

    /**
     * Update the second dataChart when the second view selecter is changed.
     */
    viewSelector2.on('change', function (ids) {
        dataChart2.set({ query: { ids: ids } }).execute();
    });

});