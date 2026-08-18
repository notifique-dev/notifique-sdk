package com.notifique.sdk.generated;

import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

final class OperationsRegistry {
    private final List<OperationRecord> operations;

    private OperationsRegistry(List<OperationRecord> operations) {
        this.operations = operations;
    }

    static OperationsRegistry load(ObjectMapper mapper) {
        try (InputStream in = OperationsRegistry.class.getResourceAsStream("/notifique/operations.json")) {
            if (in == null) {
                throw new IllegalStateException("Missing resource /notifique/operations.json");
            }
            OperationsFile file = mapper.readValue(in, OperationsFile.class);
            return new OperationsRegistry(file.operations);
        } catch (IOException e) {
            throw new IllegalStateException("Failed to load operations.json", e);
        }
    }

    List<OperationRecord> operations() {
        return operations;
    }

    int count() {
        return operations.size();
    }
}
