// Copyright 2015 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


var AccountSummaries = require('../../lib/account-summaries/account-summaries').default;
var assert = require('assert');

var fixtureAccounts = require('../_fixtures/account-summaries').items;
var fixtureAccountsEmptiesIgnored =
    require('../_fixtures/account-summaries-empties-ignored').items;



var fixtureWebProperties = fixtureAccounts
    .reduce(function(webProperties, account) {
      return account.webProperties ?
          webProperties.concat(account.webProperties) :
          webProperties;
    }, []);

var fixtureProfiles = fixtureWebProperties
    .reduce(function(profiles, webProperty) {
      return webProperty.profiles ?
          profiles.concat(webProperty.profiles) :
          profiles;
    }, []);


describe('AccountSummaries', function() {
  var summaries = new AccountSummaries(fixtureAccounts);

  describe('#constructor', function() {
    it('creates an instance with the entire account tree set', function() {
      assert.deepEqual(summaries.all(), fixtureAccounts);
    });

    it('optionally removes empty properties/views from the account tree',
        function() {
      var summariesEmptiesIgnored =
          new AccountSummaries(fixtureAccounts, {ignoreEmpty: true});

      assert(!summariesEmptiesIgnored.get({accountId: 1004}));
      assert(!summariesEmptiesIgnored.get({accountId: 1005}));
      assert(!summariesEmptiesIgnored.get({propertyId: 'UA-1006-1'}));
      assert.deepEqual(
          summariesEmptiesIgnored.all(), fixtureAccountsEmptiesIgnored);
    });
  });

  describe('#all', function() {
    it('returns the full list of accounts the user has access to.', function() {
      assert.deepEqual(summaries.all(), fixtureAccounts);
    });
  });

  describe('#allAccounts', function() {
    it('returns the full list of accounts the user has access to.', function() {
      assert.deepEqual(summaries.all(), fixtureAccounts);
    });
  });

  describe('#allWebProperties', function() {
    it('returns the full list of web properties the user has access to.',
        function() {
      assert.deepEqual(summaries.allWebProperties(), fixtureWebProperties);
    });
  });

  describe('#allProperties', function() {
    it('returns the full list of properties the user has access to.',
        function() {
      assert.deepEqual(summaries.allProperties(), fixtureWebProperties);
    });
  });

  describe('#allProfiles', function() {
    it('returns the full list of profiles the user has access to.', function() {
      assert.deepEqual(summaries.allProfiles(), fixtureProfiles);
    });
  });

  describe('#allViews', function() {
    it('returns the full list of views the user has access to.', function() {
      assert.deepEqual(summaries.allViews(), fixtureProfiles);
    });
  });

  describe('#get', function() {
    it('returns an account when passed an accountId param.', function() {
      var account = summaries.get({accountId: 1002});
      assert.equal(account.name, 'Account B');
    });
    it('returns a webProperty when passed a webPropertyId param.', function() {
      var webProperty = summaries.get({webPropertyId: 'UA-1003-1'});
      assert.equal(webProperty.name, 'WebProperty C.A');
    });
    it('returns a webProperty when passed a propertyId param.', function() {
      var webProperty = summaries.get({propertyId: 'UA-1003-1'});
      assert.equal(webProperty.name, 'WebProperty C.A');
    });
    it('returns a profile when passed a profileId param.', function() {
      var profile = summaries.get({profileId: 2006});
      assert.equal(profile.name, 'Profile A.B.C');
    });
    it('returns a profile when passed a viewId param.', function() {
      var profile = summaries.get({viewId: 2006});
      assert.equal(profile.name, 'Profile A.B.C');
    });
    it('throws when passing more than one ID, even if the IDs are for the ' +
        'same entity.', function() {

      assert.throws(function() {
        summaries.get({webPropertyId: 'UA-1003-1', profileId: 3005});
      });
      assert.throws(function() {
        // The profile with id "2001" belongs to the account with ID "1001".
        summaries.get({accountId: 1001, profileId: 2001});
      });
    });
  });

  describe('#getAccount', function() {
    it('returns the account with the specified ID.', function() {
      assert.equal(summaries.getAccount(1003).name, 'Account C');
    });
  });

  describe('#getWebProperty', function() {
    it('returns the web property with the specified ID.', function() {
      assert.equal(
          summaries.getWebProperty('UA-1005-1').name,
          'WebProperty E.A');
    });
  });

  describe('#getProperty', function() {
    it('returns the property with the specified ID.', function() {
      assert.equal(
          summaries.getProperty('UA-1005-1').name,
          'WebProperty E.A');
    });
  });

  describe('#getProfile', function() {
    it('returns the profile with the specified ID.', function() {
      assert.equal(summaries.getProfile(2010).name, 'Profile B.A.A');
    });
  });

  describe('#getView', function() {
    it('returns the view with the specified ID.', function() {
      assert.equal(summaries.getView(2010).name, 'Profile B.A.A');
    });
  });

  describe('#getAccountByProfileId', function() {
    it('returns the account that contains the specified profile ID.',
        function() {
      assert.equal(summaries.getAccountByViewId(2008).name, 'Account A');
    });
  });

  describe('#getAccountByViewId', function() {
    it('returns the account that contains the specified view ID.',
        function() {
      assert.equal(summaries.getAccountByViewId(2008).name, 'Account A');
    });
  });

  describe('#getWebPropertyByProfileId', function() {
    it('returns the web property that contains the specified profile ID.',
        function() {
      assert.equal(
          summaries.getWebPropertyByProfileId(2011).name,
          'WebProperty C.A');
    });
  });

  describe('#getPropertyByViewId', function() {
    it('returns the property that contains the specified view ID.',
        function() {
      assert.equal(
          summaries.getPropertyByViewId(2011).name,
          'WebProperty C.A');
    });
  });

  describe('#getAccountByWebPropertyId', function() {
    it('returns the account that contains the specified web property ID.',
        function() {
      assert.equal(
          summaries.getAccountByWebPropertyId('UA-1001-3').name,
          'Account A');
    });
  });

  describe('#getAccountByPropertyId', function() {
    it('returns the account that contains the specified property ID.',
        function() {
      assert.equal(
          summaries.getAccountByPropertyId('UA-1001-3').name,
          'Account A');
    });
  });

});