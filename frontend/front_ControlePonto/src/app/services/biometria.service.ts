import { BiometryType, NativeBiometric } from "capacitor-native-biometric";

async function performBiometricVerificatin(){
  const result = await NativeBiometric.isAvailable();

  if(!result.isAvailable) return;

  const verified = await NativeBiometric.verifyIdentity({
    reason: "For easy log in",
    title: "Log in",
    subtitle: "Maybe add subtitle here?",
    description: "Maybe a description too?",
  })
    .then(() => true)
    .catch(() => false);

  if(!verified) return;

  const credentials = await NativeBiometric.getCredentials({
    server: "www.example.com",
  });
}

// Save user's credentials
NativeBiometric.setCredentials({
  username: "username",
  password: "password",
  server: "www.example.com",
}).then();

// Delete user's credentials
NativeBiometric.deleteCredentials({
  server: "www.example.com",
}).then();