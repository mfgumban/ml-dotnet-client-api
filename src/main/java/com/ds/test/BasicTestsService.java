package com.ds.test;

// IMPORTANT: Do not edit. This file is generated.

import com.marklogic.client.SessionState;
import com.marklogic.client.io.Format;
import java.io.Reader;
import java.util.stream.Stream;


import com.marklogic.client.DatabaseClient;

import com.marklogic.client.impl.BaseProxy;

/**
 * API endpoints to test basic data service operations.
 */
public interface BasicTestsService {
    /**
     * Creates a BasicTestsService object for executing operations on the database server.
     *
     * The DatabaseClientFactory class can create the DatabaseClient parameter. A single
     * client object can be used for any number of requests and in multiple threads.
     *
     * @param db	provides a client for communicating with the database server
     * @return	an object for session state
     */
    static BasicTestsService on(DatabaseClient db) {
        final class BasicTestsServiceImpl implements BasicTestsService {
            private BaseProxy baseProxy;

            private BasicTestsServiceImpl(DatabaseClient dbClient) {
                baseProxy = new BaseProxy(dbClient, "/test/");
            }
            @Override
            public SessionState newSessionState() {
              return baseProxy.newSessionState();
            }

            @Override
            public void errorDetailLog() {
              baseProxy
                .request("errorDetailLog.xqy", BaseProxy.ParameterValuesKind.NONE)
                .withSession()
                .withParams(
                    )
                .withMethod("POST")
                .responseNone();
            }


            @Override
            public Reader insertDetail(String id, String itemName, SessionState session) {
              return BaseProxy.JsonDocumentType.toReader(
                baseProxy
                .request("insertDetail.xqy", BaseProxy.ParameterValuesKind.MULTIPLE_ATOMICS)
                .withSession("session", session, false)
                .withParams(
                    BaseProxy.atomicParam("id", false, BaseProxy.StringType.fromString(id)),
                    BaseProxy.atomicParam("itemName", false, BaseProxy.StringType.fromString(itemName)))
                .withMethod("POST")
                .responseSingle(false, Format.JSON)
                );
            }


            @Override
            public String insertMaster(String name, SessionState session) {
              return BaseProxy.StringType.toString(
                baseProxy
                .request("insertMaster.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession("session", session, false)
                .withParams(
                    BaseProxy.atomicParam("name", false, BaseProxy.StringType.fromString(name)))
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

        return new BasicTestsServiceImpl(db);
    }
    /**
     * Creates an object to track a session for a set of operations
     * that require session state on the database server.
     *
     * @return	an object for session state
     */
    SessionState newSessionState();

  /**
   * Explicitly causes an error response.
   *
   * 
   * 
   */
    void errorDetailLog();

  /**
   * Inserts a document representing a child entity and commits the transaction.
   *
   * @param id	provides input
   * @param itemName	provides input
   * @param session	provides input
   * @return	as output
   */
    Reader insertDetail(String id, String itemName, SessionState session);

  /**
   * Inserts a document representing a top-level entity.
   *
   * @param name	provides input
   * @param session	provides input
   * @return	The entity's unique ID.
   */
    String insertMaster(String name, SessionState session);

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
