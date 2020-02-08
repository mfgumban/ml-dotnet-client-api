FROM gradle:jdk12

# tools
RUN apt-get update && \
    apt-get install -y curl

# commands
COPY deploy.sh /workspace/deploy.sh
RUN chmod 777 /workspace/deploy.sh

CMD echo "Deployer container ready." && \
    # prevent container exit
    tail -f /dev/null