import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import pt from 'vuetify/lib/locale/pt';
import { colors } from 'vuetify/lib';

Vue.use(Vuetify);

export default new Vuetify({
    lang: {
        locales: { pt },
        current: 'pt',
    },
    theme: {
        dark: true,
        default: 'dark',
        options: {
            customProperties: true,
        },
        themes: {
            light: {
                menuActive: colors.green.lighten5,
                chipGreen: colors.green.lighten5,
                chipFontGreen: colors.green.lighten2,
                chipRed: colors.red.lighten5,
                chipFontRed: colors.red.lighten2,
                cadastroBackground: '#4CAF50',
            },
            dark: {
                menuActive: colors.blueGrey.lighten5,
                chipGreen: colors.green.lighten3,
                chipFontGreen: colors.green.darken2,
                chipRed: colors.red.lighten3,
                chipFontRed: colors.red,
                cadastroBackground: '#222222',
            },
        }
    }
});

