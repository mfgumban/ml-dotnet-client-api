package com.ds.test;

// IMPORTANT: Do not edit. This file is generated.



import com.marklogic.client.DatabaseClient;

import com.marklogic.client.impl.BaseProxy;

/**
 * API endpoints to test atomic data types.
 */
public interface AtomicTypeTestsService {
    /**
     * Creates a AtomicTypeTestsService object for executing operations on the database server.
     *
     * The DatabaseClientFactory class can create the DatabaseClient parameter. A single
     * client object can be used for any number of requests and in multiple threads.
     *
     * @param db	provides a client for communicating with the database server
     * @return	an object for session state
     */
    static AtomicTypeTestsService on(DatabaseClient db) {
        final class AtomicTypeTestsServiceImpl implements AtomicTypeTestsService {
            private BaseProxy baseProxy;

            private AtomicTypeTestsServiceImpl(DatabaseClient dbClient) {
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
            public java.time.LocalDate returnDate(java.time.LocalDate value) {
              return BaseProxy.DateType.toLocalDate(
                baseProxy
                .request("returnDate.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.DateType.fromLocalDate(value)))
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


            @Override
            public Double returnDouble(Double value) {
              return BaseProxy.DoubleType.toDouble(
                baseProxy
                .request("returnDouble.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.DoubleType.fromDouble(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public Float returnFloat(Float value) {
              return BaseProxy.FloatType.toFloat(
                baseProxy
                .request("returnFloat.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.FloatType.fromFloat(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public Integer returnInteger(Integer value) {
              return BaseProxy.IntegerType.toInteger(
                baseProxy
                .request("returnInteger.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.IntegerType.fromInteger(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public Long returnLong(Long value) {
              return BaseProxy.LongType.toLong(
                baseProxy
                .request("returnLong.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.LongType.fromLong(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public Integer returnNullableValueType(Integer value) {
              return BaseProxy.IntegerType.toInteger(
                baseProxy
                .request("returnNullableValueType.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", true, BaseProxy.IntegerType.fromInteger(value)))
                .withMethod("POST")
                .responseSingle(true, null)
                );
            }


            @Override
            public String returnString(String value) {
              return BaseProxy.StringType.toString(
                baseProxy
                .request("returnString.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.StringType.fromString(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public java.time.LocalTime returnTime(java.time.LocalTime value) {
              return BaseProxy.TimeType.toLocalTime(
                baseProxy
                .request("returnTime.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.TimeType.fromLocalTime(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public String returnTimeSpan(String value) {
              return BaseProxy.DayTimeDurationType.toString(
                baseProxy
                .request("returnTimeSpan.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.DayTimeDurationType.fromString(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public Integer returnUnsignedInteger(Integer value) {
              return BaseProxy.UnsignedIntegerType.toInteger(
                baseProxy
                .request("returnUnsignedInteger.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.UnsignedIntegerType.fromInteger(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }


            @Override
            public Long returnUnsignedLong(Long value) {
              return BaseProxy.UnsignedLongType.toLong(
                baseProxy
                .request("returnUnsignedLong.xqy", BaseProxy.ParameterValuesKind.SINGLE_ATOMIC)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("value", false, BaseProxy.UnsignedLongType.fromLong(value)))
                .withMethod("POST")
                .responseSingle(false, null)
                );
            }

        }

        return new AtomicTypeTestsServiceImpl(db);
    }

  /**
   * Accepts and returns a boolean.
   *
   * @param value	provides input
   * @return	as output
   */
    Boolean returnBoolean(Boolean value);

  /**
   * Accepts and returns a date.
   *
   * @param value	provides input
   * @return	as output
   */
    java.time.LocalDate returnDate(java.time.LocalDate value);

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

  /**
   * Accepts and returns a double.
   *
   * @param value	provides input
   * @return	as output
   */
    Double returnDouble(Double value);

  /**
   * Accepts and returns a float.
   *
   * @param value	provides input
   * @return	as output
   */
    Float returnFloat(Float value);

  /**
   * Accepts and returns an integer.
   *
   * @param value	provides input
   * @return	as output
   */
    Integer returnInteger(Integer value);

  /**
   * Accepts and returns a long.
   *
   * @param value	provides input
   * @return	as output
   */
    Long returnLong(Long value);

  /**
   * Test endpoint for a Nullable<T> type.
   *
   * @param value	provides input
   * @return	as output
   */
    Integer returnNullableValueType(Integer value);

  /**
   * Accepts and returns a string.
   *
   * @param value	provides input
   * @return	as output
   */
    String returnString(String value);

  /**
   * Accepts and returns a time.
   *
   * @param value	provides input
   * @return	as output
   */
    java.time.LocalTime returnTime(java.time.LocalTime value);

  /**
   * Accepts and returns a time span (dayTimeDuration).
   *
   * @param value	provides input
   * @return	as output
   */
    String returnTimeSpan(String value);

  /**
   * Accepts and returns an unsigned integer.
   *
   * @param value	provides input
   * @return	as output
   */
    Integer returnUnsignedInteger(Integer value);

  /**
   * Accepts and returns an unsigned long.
   *
   * @param value	provides input
   * @return	as output
   */
    Long returnUnsignedLong(Long value);

}
