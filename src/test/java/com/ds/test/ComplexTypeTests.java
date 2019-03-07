package com.ds.test;

import java.io.*;
import java.util.*;
import java.util.stream.*;
import java.time.*;

import org.junit.jupiter.api.*;
import com.marklogic.client.*;
import com.ds.TestBase;
import com.ds.test.ComplexTypeTestsService;


public class ComplexTypeTests extends TestBase {
  private static DatabaseClient dbClient;
  private static ComplexTypeTestsService testService;

  @BeforeAll
  public static void setUp() {
    dbClient = getClient();
    testService = ComplexTypeTestsService.on(dbClient);
  }
  
  @AfterAll
  public static void tearDown() {
    dbClient.release();
  }
  
  @Test
  public void testReturnBinary() throws IOException {
    System.out.println("Working Directory = " + System.getProperty("user.dir"));
    File file = new File("src/test/resources/marklogic-logo-social.jpg");
    InputStream parameter = new FileInputStream(file);
    InputStream response = testService.returnBinary(parameter);
  }
}