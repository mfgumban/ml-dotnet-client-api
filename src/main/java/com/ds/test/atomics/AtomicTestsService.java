package com.ds.test.atomics;

// IMPORTANT: Do not edit. This file is generated.



import com.marklogic.client.DatabaseClient;

import com.marklogic.client.impl.BaseProxy;

/**
 * API endpoints to test atomic data types.
 */
public interface AtomicTestsService {
    /**
     * Creates a AtomicTestsService object for executing operations on the database server.
     *
     * The DatabaseClientFactory class can create the DatabaseClient parameter. A single
     * client object can be used for any number of requests and in multiple threads.
     *
     * @param db	provides a client for communicating with the database server
     * @return	an object for session state
     */
    static AtomicTestsService on(DatabaseClient db) {
        final class AtomicTestsServiceImpl implements AtomicTestsService {
            private BaseProxy baseProxy;

            private AtomicTestsServiceImpl(DatabaseClient dbClient) {
                baseProxy = new BaseProxy(dbClient, "/test/atomics/");
            }

            @Override
            public Boolean returnBoolean(Boolean value) {
              return BaseProxy.BooleanType.toBoolean(
                baseProxy
                .request("returnBoolean.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.BooleanType.fromBoolean(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
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
            public String returnDecimal(String value) {
              return BaseProxy.DecimalType.toString(
                baseProxy
                .request("returnDecimal.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.DecimalType.fromString(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }

        }

        return new AtomicTestsServiceImpl(db);
    }

  /**
   * Accepts and returns a boolean.
   *
   * @param value	provides input
   * @return	as output
   */
    Boolean returnBoolean(Boolean value);

  /**
   * Accepts and returns a dateTime.
   *
   * @param value	provides input
   * @return	as output
   */
    java.time.LocalDateTime returnDateTime(java.time.LocalDateTime value);

  /**
   * Accepts and returns a decimal.
   *
   * @param value	provides input
   * @return	as output
   */
    String returnDecimal(String value);

}
