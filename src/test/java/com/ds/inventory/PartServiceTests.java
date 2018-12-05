package com.ds.inventory;

import java.io.*;
import java.util.*;
import java.util.stream.*;

import org.junit.jupiter.api.*;
import com.marklogic.client.*;
import com.ds.TestBase;
import com.ds.inventory.PartService;


public class PartServiceTests extends TestBase {
  private static DatabaseClient dbClient;
  private static PartService partService;

  @BeforeAll
  public static void setUp() {
    dbClient = getClient();
    partService = PartService.on(dbClient);
  }
  
  @AfterAll
  public static void tearDown() {
    dbClient.release();
  }

  @Test
  void testListParts() throws IOException {
    // parameters
    int pageLength = 10;
    List<String> options = Arrays.asList("the", "quick", "brown", "fox");
    StringReader doc = new StringReader("<test><node>1</node></test>");

    Stream<String> retVal = partService.listParts(pageLength, options.stream(), doc);
    
    List<String> results = retVal.collect(Collectors.toList());
    results.forEach(System.out::println);
  }
}