pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:9.0'
      args '-u root:root'
    }
  }

  options {
    timestamps()
    ansiColor('xterm')
    disableConcurrentBuilds()
  }

  environment {
    BUILD_CONFIGURATION = 'Release'
    TEST_RESULTS_DIR = 'TestResults'
    PUBLISH_DIR = 'out'
  }

  stages {

    stage('Checkout') {
      steps {
        echo "Checking out source code..."
        checkout scm
      }
    }

    stage('Restore') {
      steps {
        echo "Restoring NuGet packages..."
        sh 'dotnet restore'
      }
    }

    stage('Build') {
      steps {
        echo "Building solution..."
        sh 'dotnet build --configuration $BUILD_CONFIGURATION --no-restore'
      }
    }

    stage('Test') {
      steps {
        echo "Running tests..."
        sh '''
          dotnet test Api.Tests \
            --configuration $BUILD_CONFIGURATION \
            --no-build \
            --logger "trx;LogFileName=test.trx" \
            --results-directory $TEST_RESULTS_DIR
        '''
      }
      post {
        always {
          echo "Archiving test results..."
          archiveArtifacts artifacts: "${TEST_RESULTS_DIR}/**/*.trx", fingerprint: true
          junit allowEmptyResults: true, testResults: "${TEST_RESULTS_DIR}/**/*.trx"
        }
        unsuccessful {
          echo "Tests failed!"
        }
      }
    }

    stage('Publish') {
      steps {
        echo "Publishing project..."
        sh 'dotnet publish Api -c $BUILD_CONFIGURATION -o $PUBLISH_DIR'
      }
    }

    stage('Archive') {
      steps {
        echo "Archiving published artifacts..."
        archiveArtifacts artifacts: "$PUBLISH_DIR/**", fingerprint: true
      }
    }
  }

  post {
    success {
      echo "Build and tests completed successfully!"
    }
    failure {
      echo "Build failed. Check logs for details."
    }
  }
}
