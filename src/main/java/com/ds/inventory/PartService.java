package com.ds.inventory;

// IMPORTANT: Do not edit. This file is generated.

import java.util.stream.Stream;
import com.marklogic.client.io.Format;
import java.io.Reader;


import com.marklogic.client.DatabaseClient;

import com.marklogic.client.impl.BaseProxy;

/**
 * Provides the necessary functions to inspect parts currently in inventory.
 */
public interface PartService {
    /**
     * Creates a PartService object for executing operations on the database server.
     *
     * The DatabaseClientFactory class can create the DatabaseClient parameter. A single
     * client object can be used for any number of requests and in multiple threads.
     *
     * @param db	provides a client for communicating with the database server
     * @return	an object for session state
     */
    static PartService on(DatabaseClient db) {
        final class PartServiceImpl implements PartService {
            private BaseProxy baseProxy;

            private PartServiceImpl(DatabaseClient dbClient) {
                baseProxy = new BaseProxy(dbClient, "/inventory/part/");
            }

            @Override
            public Stream<String> listParts(Integer pageLength, Stream<String> options, Reader doc) {
              return BaseProxy.StringType.toString(
                baseProxy
                .request("listParts.xqy", BaseProxy.ParameterValuesKind.MULTIPLE_MIXED)
                .withSession()
                .withParams(
                    BaseProxy.atomicParam("pageLength", true, BaseProxy.IntegerType.fromInteger(pageLength)),
                    BaseProxy.atomicParam("options", true, BaseProxy.StringType.fromString(options)),
                    BaseProxy.documentParam("doc", true, BaseProxy.XmlDocumentType.fromReader(doc)))
                .withMethod("POST")
                .responseMultiple(false, null)
                );
            }

        }

        return new PartServiceImpl(db);
    }

  /**
   * Returns all available parts.
   *
   * @param pageLength	The maximum number of items to retrieve.
   * @param options	Test multiple parameters option.
   * @param doc	Test doc parameter
   * @return	Test multiple returns.
   */
    Stream<String> listParts(Integer pageLength, Stream<String> options, Reader doc);

}
