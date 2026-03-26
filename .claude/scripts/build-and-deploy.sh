#!/bin/bash
# Auto build-and-deploy hook for LocalMCPServer
# Triggered by Claude Code PostToolUse on Write|Edit tools
# Only runs when a .cs file inside the LocalMCPServer repo is changed

set -e

# Read hook input from stdin
INPUT=$(cat)
FILE_PATH=$(echo "$INPUT" | jq -r '.tool_input.file_path // .tool_response.filePath // ""')

# Only proceed if a .cs file was changed
if [[ "$FILE_PATH" != *.cs ]]; then
  exit 0
fi

# Only proceed if the file is inside the LocalMCPServer repo
if [[ "$FILE_PATH" != *"LocalMCPServer"* ]]; then
  exit 0
fi

echo ""
echo "============================================"
echo " Auto Build & Deploy — LocalMCPServer"
echo " Changed file: $FILE_PATH"
echo "============================================"

AWS_PROFILE="105927215370_LytxHackathonUser"
AWS_REGION="us-east-1"
AWS_ACCOUNT="105927215370"
ECR_REPO="local-mcp-server"
ECR_URI="${AWS_ACCOUNT}.dkr.ecr.${AWS_REGION}.amazonaws.com/${ECR_REPO}:latest"
CLUSTER="mcp-cluster"
SERVICE="mcp-service"
REPO_PATH="C:/Users/NareshKumarV/source/repos/LocalMCPServer"

# Change to repo root
cd "$REPO_PATH"

echo ""
echo "[1/4] Logging in to Amazon ECR..."
aws ecr get-login-password \
  --region "$AWS_REGION" \
  --profile "$AWS_PROFILE" \
| docker login \
  --username AWS \
  --password-stdin \
  "${AWS_ACCOUNT}.dkr.ecr.${AWS_REGION}.amazonaws.com"

echo ""
echo "[2/4] Building Docker image..."
docker build -t "$ECR_REPO" .

echo ""
echo "[3/4] Pushing image to ECR..."
docker tag "${ECR_REPO}:latest" "$ECR_URI"
docker push "$ECR_URI"

echo ""
echo "[4/4] Triggering ECS service update..."
MSYS_NO_PATHCONV=1 aws ecs update-service \
  --cluster "$CLUSTER" \
  --service "$SERVICE" \
  --force-new-deployment \
  --region "$AWS_REGION" \
  --profile "$AWS_PROFILE" \
  --output text \
  --query 'service.deployments[0].status'

echo ""
echo "============================================"
echo " Deploy triggered successfully!"
echo " Cluster : $CLUSTER"
echo " Service : $SERVICE"
echo "============================================"
echo ""
