export default {
  responseHandling: async (promise, accept = [200, 202, 204]) => {
    let issuccess = false,
      result = {};
    try {
      result = await promise;
      issuccess = accept.includes(result.status);
    } catch (ex) {
      result = ex;
    }

    return {
      issuccess,
      result
    };
  }
};
