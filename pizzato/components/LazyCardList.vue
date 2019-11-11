<template>
  <cards-list
        :cards="restaurants"
        :label="heading"
      />
</template>

<script>
import CardsList from './CardsList'

export default {
    name: "LazyCardList",
    components: { CardsList },
    props: ['cards', 'label'],
    data: () => ({
        observer: null,
        intersected: false 
    }),
    computed: {
        restaurants() {
            return this.intersected ? this.cards : [];
        },
        heading() {
            return this.intersected ? this.label : '';
        }
    },
    mounted() {
        this.observer = new IntersectionObserver(entries => {
            const cardList = entries[0];

            if (cardList.isIntersecting) {
                this.intersected = true;
                this.observer.disconnect();
            }
        });

        this.observer.observe(this.$el);
    },
    destroyed() {
        this.observer.disconnect();
    }
}
</script>

<style>

</style>