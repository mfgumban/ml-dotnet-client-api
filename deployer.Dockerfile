# This Dockerfile assumes the build context to be the project root directory
FROM gradle:jdk13 AS deploy
WORKDIR /project

# tools
RUN apt-get update && \
    apt-get install -y curl

# gradle project
COPY test .
RUN chmod 777 wait-for-ml.sh

# deploy
WORKDIR /project
CMD ./wait-for-ml.sh $MLHOST 8001 $MLUSER $MLPWD && \
    gradle -PmlHost=$MLHOST installCertificate && \
    gradle -PmlHost=$MLHOST mlDeploy