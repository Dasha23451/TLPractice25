const create = (oldJsonStr, newJsonStr) => {
  const oldObj = oldJsonStr ? JSON.parse(oldJsonStr) : {};
  const newObj = newJsonStr ? JSON.parse(newJsonStr) : {};

  const keysOld = Object.keys(oldObj);
  const keysNew = Object.keys(newObj);
  const allKeys = [...new Set([...keysOld, ...keysNew])];

  const result = {};

  allKeys.forEach((key) => {
    const oldValue = oldObj[key];
    const newValue = newObj[key];

    if (!(key in oldObj)) {
      result[key] = {
        type: "new",
        newValue: newValue,
      };
    } else if (!(key in newObj)) {
      result[key] = {
        type: "deleted",
        oldValue: oldValue,
      };
    } else if (JSON.stringify(oldValue) === JSON.stringify(newValue)) {
      result[key] = {
        type: "unchanged",
        oldValue: oldValue,
        newValue: newValue,
      };
    } else {
      result[key] = {
        type: "changed",
        oldValue: oldValue,
        newValue: newValue,
      };
    }
  });

  return result;
};

export const JsonDiff = {
  create,
};
