export default class AccountService {
  login(login) {
    return new Promise((resolve, reject) => {
      if (login.email === 'admin' && login.password === 'admin') {
        resolve('Login successful');
      } else {
        reject('Login failed');
      }
    });
  }
}
