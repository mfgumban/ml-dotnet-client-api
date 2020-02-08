FROM mcr.microsoft.com/dotnet/core/sdk:3.1

#tools
RUN dotnet tool install -g dotnet-reportgenerator-globaltool --version 4.4.6
ENV PATH="/root/.dotnet/tools:${PATH}"

# commands
COPY run-tests.sh /workspace/run-tests.sh
RUN chmod 777 /workspace/run-tests.sh

CMD echo "Test runner container ready." && \
    # prevent container exit
    tail -f /dev/null