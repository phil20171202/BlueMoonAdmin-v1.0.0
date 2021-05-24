gapi.analytics.ready(function () {

    /**
     * Authorize the user immediately if the user has already granted access.
     * If no access has been created, render an authorize button inside the
     * element with the ID "embed-api-auth-container".
     */
    gapi.analytics.auth.authorize({
        container: 'embed-api-auth',
        clientid: '741820747648-0q7381obn2s853don1f4h72gctofpns3.apps.googleusercontent.com'
    });

});