pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:8.0'
    }
  }
  options { timestamps(); ansiColor('xterm') }
  stages {
    stage('Checkout') {
      steps { checkout scm }
    }
    stage('Restore') {
      steps { sh 'dotnet restore' }
    }
    stage('Build') {
      steps { sh 'dotnet build --configuration Release --no-restore' }
    }
    stage('Test') {
      steps { sh 'dotnet test Api.Tests --logger "trx;LogFileName=test.trx" --no-build' }
      post {
        always {
          archiveArtifacts artifacts: '**/TestResults/*.trx', fingerprint: true
        }
      }
    }
    stage('Publish') {
      steps { sh 'dotnet publish Api -c Release -o out' }
    }
    stage('Archive') {
      steps { archiveArtifacts artifacts: 'out/**', fingerprint: true }
    }
  }
}