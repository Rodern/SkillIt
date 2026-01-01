/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.{razor,html,js}',
        "./node_modules/tw-elements/dist/js/**/*.js"
    ],
    darkMode: 'class',
    theme: {
        extend: {}/*,
        fontFamily: {
            sans: ["Roboto", "sans-serif"],
            body: ["Roboto", "sans-serif"],
            mono: ["ui-monospace", "monospace"],
        }*/
    },
    plugins: [require("tw-elements/dist/plugin.cjs")],
    corePlugins: {
        preflight: false,
    },
}
