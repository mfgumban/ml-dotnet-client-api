package com.ds.test;

import java.io.*;
import java.util.*;
import java.util.stream.*;
import java.time.*;

import org.junit.jupiter.api.*;
import com.marklogic.client.*;
import com.ds.TestBase;
import com.ds.test.TestService;


public class TestServiceTests extends TestBase {
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
  public void testReturnNone() throws IOException {
    testService.returnNone();
  }

  @Test
  public void testReturnMultipleAtomic() throws IOException {
    String response = testService.returnMultipleAtomic("the quick brown fox", 1234, LocalDateTime.now());
    System.out.println(response);
  }

  @Test
  public void testReturnMultiValue() throws IOException {
    List<Integer> values = Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
    Stream<Integer> response = testService.returnMultiValue(values.stream());
    List<Integer> results = response.collect(Collectors.toList());
    results.forEach(System.out::println);
  }

  @Test
  public void testReturnDateTime() throws IOException {
    LocalDateTime parameter = LocalDateTime.now();
    LocalDateTime response = testService.returnDateTime(parameter);
    System.out.println(String.format("Parameter: %s\nResponse: %s", parameter, response));
  }
}