package com.ds.test;

import java.io.*;
import java.util.*;
import java.util.stream.*;
import java.time.*;

import org.junit.jupiter.api.*;
import com.marklogic.client.*;
import com.ds.TestBase;
import com.ds.test.TestService;


public class AtomicTestsServiceTests extends TestBase {
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

  @Test
  public void testReturnBooleanTrue() throws IOException {
    Boolean parameter = true;
    Boolean response = testService.returnBoolean(parameter);
    System.out.println(String.format("Parameter: %s\nResponse: %s", parameter, response));
  }

  @Test
  public void testReturnBooleanFalse() throws IOException {
    Boolean parameter = false;
    Boolean response = testService.returnBoolean(parameter);
    System.out.println(String.format("Parameter: %s\nResponse: %s", parameter, response));
  }

  @Test
  public void testReturnDecimal() throws IOException {
    String parameter = "1234";
    String response = testService.returnDecimal(parameter);
    System.out.println(String.format("Parameter: %s\nResponse: %s", parameter, response));
  }
}