#!/bin/bash
set -x
echo -n "Configuring Credentials..."
aws configure set aws_access_key_id test
aws configure set aws_secret_access_key test
aws configure set default.region us-east-1
aws configure set default.output json
echo "[OK]"

echo -n "Configuring SQS Queues..."
aws --endpoint-url http://10.0.2.20:4566 --region us-east-1 sqs create-queue --queue-name backend-challenge-bike-orders
aws --endpoint-url http://10.0.2.20:4566 --region us-east-1 sqs create-queue --queue-name backend-challenge-bike-orders-dlq
echo "[SQS] OK"

echo -n "Configuring S3 Buckets..."

aws --endpoint-url http://10.0.2.20:4566 --region us-east-1 s3 mb s3://bikedocs
aws --endpoint-url http://10.0.2.20:4566 --region us-east-1 s3 mb s3://logs

echo "[S3] OK"
echo -n "Ready."