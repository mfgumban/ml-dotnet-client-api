package com.ds.test;

import java.io.*;
import java.util.*;
import java.util.stream.*;
import java.time.*;

import org.junit.jupiter.api.*;
import com.marklogic.client.*;
import com.ds.TestBase;
import com.ds.test.TestService;


public class ComplexTypeTests extends TestBase {
  private static DatabaseClient dbClient;
  private static TestService testService;

  @BeforeAll
  public static void setUp() {
    dbClient = getClient();
    testService = TestService.on(dbClient);
  }
  
  @AfterAll
  public static void tearDown() {
    dbClient.release();
  }
  
  @Test
  public void testReturnDateTime() throws IOException {
    LocalDateTime parameter = LocalDateTime.now();
    LocalDateTime response = testService.returnDateTime(parameter);
    System.out.println(String.format("Parameter: %s\nResponse: %s", parameter, response));
  }
}