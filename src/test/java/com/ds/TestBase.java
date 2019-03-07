package com.ds;

import com.marklogic.client.DatabaseClient;
import com.marklogic.client.DatabaseClientFactory;
import com.marklogic.client.DatabaseClientFactory.DigestAuthContext;


public class TestBase {
  protected static DatabaseClient getClient() {
    // For Fiddler intercept
    System.setProperty("http.proxyHost", "127.0.0.1");
    System.setProperty("https.proxyHost", "127.0.0.1");
    System.setProperty("http.proxyPort", "8888");
    System.setProperty("https.proxyPort", "8888");

    DatabaseClient client = DatabaseClientFactory.newClient(
      //"localhost",
      "ipv4.fiddler",
      8019, 
      new DigestAuthContext("admin", "admin"));
    return client;
  }
}