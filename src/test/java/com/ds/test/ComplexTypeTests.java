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

  @Test
  public void testReturnTextDoc() throws IOException {
    String inputData = "The quick brown fox jumped over the lazy dog beside the riverbank.";
    Reader input = new StringReader(inputData);
    Reader result = testService.returnTextDoc(input);
    
    int charAsInt;
    String resultData = "";
    while ((charAsInt = result.read()) != -1) {
      resultData += (char)charAsInt;
    }
    System.out.println(resultData);

    input.close();
    result.close();
  }
}