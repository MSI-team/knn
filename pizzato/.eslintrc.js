module.exports = {
  root: true,
  env: {
    browser: true,
    node: true
  },
  parserOptions: {
    parser: 'babel-eslint'
  },
  extends: [
    '@nuxtjs',
    //'prettier',
    //'prettier/vue',
    //'plugin:prettier/recommended',
    'plugin:nuxt/recommended',
    'eslint:recommended',
    "plugin:vue/recommended",
  ],
  plugins: [
    //'prettier'
  ],
  // add your custom rules here
  rules: {
    'nuxt/no-cjs-in-config': 'off',
    "vue/component-name-in-template-casing": 'off',
    // 'prettier/prettier': [
    //   'error',
    //   {
    //     htmlWhitespaceSensitivity: 'ignore',
    //     semi: false,
    //     singleQuote: true
    //   }
    // ],
  }
}
