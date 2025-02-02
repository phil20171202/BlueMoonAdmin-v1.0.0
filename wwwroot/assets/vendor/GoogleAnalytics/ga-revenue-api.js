﻿gapi.analytics.ready(function () {

    /**
   * Authorize the user immediately if the user has already granted access.
   * If no access has been created, render an authorize button inside the
   * element with the ID "embed-api-auth-container".
   */
    gapi.analytics.auth.authorize({
        container: 'embed-api-revenue',
        clientid: '741820747648-0q7381obn2s853don1f4h72gctofpns3.apps.googleusercontent.com'
    });

    /**
     * Create a new ViewSelector instance to be rendered inside of an
     * element with the id "view-selector-container".
     */
    var viewSelector = new gapi.analytics.ViewSelector({
        container: 'view-selector-container-revenue'
    });

    // Render the view selector to the page.
    viewSelector.execute();


    /**
     * Create a new DataChart instance with the given query parameters
     * and Google chart options. It will be rendered inside an element
     * with the id "chart-container".
     */
    var dataChart = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: 'ga:newUsers',
            dimensions: 'ga:date',
            'start-date': '30daysAgo',
            'end-date': 'yesterday'
        },
        chart: {
            container: 'chart-container-revenue',
            type: 'LINE',
            options: {
                width: '100%'
            }
        }
    });


    /**
     * Render the dataChart on the page whenever a new view is selected.
     */
    viewSelector.on('change', function (ids) {
        dataChart.set({ query: { ids: ids } }).execute();
    });

});
