package com.ds.test;

// IMPORTANT: Do not edit. This file is generated.

import java.util.stream.Stream;


import com.marklogic.client.DatabaseClient;

import com.marklogic.client.impl.BaseProxy;

/**
 * Test service endpoints.
 */
public interface TestService {
    /**
     * Creates a TestService object for executing operations on the database server.
     *
     * The DatabaseClientFactory class can create the DatabaseClient parameter. A single
     * client object can be used for any number of requests and in multiple threads.
     *
     * @param db	provides a client for communicating with the database server
     * @return	an object for session state
     */
    static TestService on(DatabaseClient db) {
        final class TestServiceImpl implements TestService {
            private BaseProxy baseProxy;

            private TestServiceImpl(DatabaseClient dbClient) {
                baseProxy = new BaseProxy(dbClient, "/test/");
            }

            @Override
            public java.time.LocalDateTime returnDateTime(java.time.LocalDateTime value) {
              return BaseProxy.DateTimeType.toLocalDateTime(
                baseProxy
                .request("returnDateTime.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.DateTimeType.fromLocalDateTime(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public String returnMultipleAtomic(String value1, Integer value2, java.time.LocalDateTime value3) {
              return BaseProxy.StringType.toString(
                baseProxy
                .request("returnMultipleAtomic.xqy", BaseProxy.ParameterValuesKind.MULTIPLE_ATOMICS)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value1", false, BaseProxy.StringType.fromString(value1)),
                    BaseProxy.atomicParam("value2", false, BaseProxy.IntegerType.fromInteger(value2)),
                    BaseProxy.atomicParam("value3", false, BaseProxy.DateTimeType.fromLocalDateTime(value3)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public Stream<Integer> returnMultiValue(Stream<Integer> values) {
              return BaseProxy.IntegerType.toInteger(
                baseProxy
                .request("returnMultiValue.xqy", BaseProxy.ParameterValuesKind.MULTIPLE_ATOMICS)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("values", false, BaseProxy.IntegerType.fromInteger(values)))
                .withMethod("POST")
                .responseMultiple(false, null)
                );
            }


            @Override
            public void returnNone() {
              baseProxy
                .request("returnNone.xqy", BaseProxy.ParameterValuesKind.NONE)
                .withSession()
                .withParams(
                    )
                .withMethod("POST")
                .responseNone();
            }

        }

        return new TestServiceImpl(db);
    }

  /**
   * Accepts and returns a dateTime.
   *
   * @param value	provides input
   * @return	as output
   */
    java.time.LocalDateTime returnDateTime(java.time.LocalDateTime value);

  /**
   * Accepts multiple atomic values and returns a multi-line string containing the server-side values.
   *
   * @param value1	provides input
   * @param value2	provides input
   * @param value3	provides input
   * @return	as output
   */
    String returnMultipleAtomic(String value1, Integer value2, java.time.LocalDateTime value3);

  /**
   * Accepts and returns a single parameter with multiple values.
   *
   * @param values	provides input
   * @return	as output
   */
    Stream<Integer> returnMultiValue(Stream<Integer> values);

  /**
   * No parameters and empty response.
   *
   * 
   * 
   */
    void returnNone();

}
