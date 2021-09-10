ECHO OFF
CLS
ECHO ******************************************************
set @verarg=%1
echo "CRIA IMAGEM VERSAO:" %@verarg%
ECHO ******************************************************
set /p contBuild=Continuar com o script [s/n]?:

if "%contBuild%"== "n" (
  exit /B
)

if "%contBuild%"== "N" (
  exit /B
)


pause

docker build . -f Dockerfile.Mercado.Assistente.Api -t primevoid/maapi.%@verarg%.0


docker push primevoid/maapi.%@verarg%.0



echo =====================================================================
echo ============   IMAGEM ENVIADA PARA O  DOCKERHUB       ===============
echo =====================================================================